using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slots : MonoBehaviour  , IPointerClickHandler {
    static int j;
    public ObjectUse objuse;
    public bool isFull = false;
    public Sprite Image;
    public bool isSet;
    public GameObject go;
    public Image image;
    public string tag;

	// Use this for initialization
	void Start () {
        Inventory.inventory.slots[0] = GameObject.Find("Slot").GetComponent<Slots>();
        Inventory.inventory.slots[1] = GameObject.Find("Slot (1)").GetComponent<Slots>();
        Inventory.inventory.slots[2] = GameObject.Find("Slot (2)").GetComponent<Slots>();
        Inventory.inventory.slots[3] = GameObject.Find("Slot (3)").GetComponent<Slots>();
        Inventory.inventory.slots[4] = GameObject.Find("Slot (4)").GetComponent<Slots>();
        Inventory.inventory.slots[5] = GameObject.Find("Slot (5)").GetComponent<Slots>();
        Inventory.inventory.slots[6] = GameObject.Find("Slot (6)").GetComponent<Slots>();
        //UnityEngine.Object.DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isSet)
        {
            go.SetActive(true);
            image.sprite = Image;
            //GameObject.DontDestroyOnLoad(this.gameObject);
            //image = Image;
        }
	}

    //public void OnPointerEnter(PointerEventData ped)
    //{
    //    //Debug.Log("Hey!" + gameObject);
    //    //int i = Array.IndexOf(Inventory.inventory.slots, gameObject.GetComponent<Slots>());
    //    if (Inventory.inventory.slots[i].isFull)
    //    {
    //        //Debug.Log("Object Found!");
    //        if (i==8)
    //        {
    //            Debug.Log("Object Found!");
    //        }
    //    }
    //}

    public void OnPointerClick(PointerEventData ped)
    {
        Debug.Log("CLICKED");
        if (ped.pointerId == -1)
        {
            Debug.Log(Inventory.inventory.slots.Length);
            //Inventory.inventory.slots[0] = GameObject.Find("Slot").GetComponent<Slots>();
            //Inventory.inventory.slots[1] = GameObject.Find("Slot (1)").GetComponent<Slots>();
            //Inventory.inventory.slots[2] = GameObject.Find("Slot (2)").GetComponent<Slots>();
            //Inventory.inventory.slots[3] = GameObject.Find("Slot (3)").GetComponent<Slots>();
            //Inventory.inventory.slots[4] = GameObject.Find("Slot (4)").GetComponent<Slots>();
            //Inventory.inventory.slots[5] = GameObject.Find("Slot (5)").GetComponent<Slots>();
            //Inventory.inventory.slots[6] = GameObject.Find("Slot (6)").GetComponent<Slots>();
            Debug.Log(Inventory.inventory.slots[0]);
            Debug.Log(gameObject.GetComponent<Slots>());
            int i = Array.IndexOf(Inventory.inventory.slots, gameObject.GetComponent<Slots>());
            Debug.Log(i);
            objuse.i = i;
            //Debug.Log("i"+ i);
            //Debug.Log(Inventory.inventory.slots[i].isFull);
            
            if (Inventory.inventory.slots[i].isFull && objuse.IsPicked == false)
            {
                j = i;
                Debug.Log(j);
                //Debug.Log("YO");
                objuse.image = image;
                objuse.IsPicked = true;
                objuse.tag = tag;
                isSet = false;
                go.SetActive(false);
                //Inventory.inventory.slots[i].isFull = false;
            }
            else if (/*!Inventory.inventory.slots[i].isFull && */objuse.IsPicked == true && !Inventory.inventory.slots[i].isSet) 
            {
                Debug.Log(j);
                go.SetActive(true);
                isSet = true;
                objuse.IsPicked = false;
                Inventory.inventory.slots[i].isFull = true;
                Inventory.inventory.slots[i].Image = objuse.image.sprite;
                Debug.Log("i is " + i + "and j is " + j);
                if (j!= i)
                {
                    Inventory.inventory.slots[j].isFull = false;
                }
            }
        }
    }
}
