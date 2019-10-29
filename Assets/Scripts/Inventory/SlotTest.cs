using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SlotTest : MonoBehaviour, IPointerClickHandler
{
    static int j;
    public ObjectUse objuse;
    public bool isFull = false;
    public Sprite Image;
    public bool isSet;
    public GameObject go;
    public Image image;
    public string tag;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSet)
        {
            go.SetActive(true);
            image.sprite = Image;
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
            int i = Array.IndexOf(Inventory.inventory.slots, gameObject.GetComponent<Slots>());
            objuse.i = i;
            //Debug.Log("i"+ i);
            Debug.Log(Inventory.inventory.slots[i].isFull);

            if (Inventory.inventory.slots[i].isFull && objuse.IsPicked == false)
            {
                j = i;
                Debug.Log(j);
                //Debug.Log("YO");
                objuse.image = image;
                objuse.IsPicked = true;
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
                if (j != i)
                {
                    Inventory.inventory.slots[j].isFull = false;
                }
            }
        }
    }
}
