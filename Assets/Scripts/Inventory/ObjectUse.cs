using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUse : MonoBehaviour {
    //public static ObjectUse objuse { get; private set; }
    public Interactable interactable;
    public Image image;
    public Sprite spr;
    public bool IsPicked;
    public GameObject go;
    public int i;
    public string tag;

    Ray ray;
    RaycastHit rc;
    Camera cam;
    
    
    void Update()
    {
        
        //Debug.Log(IsPicked);
        gameObject.transform.position = Input.mousePosition;
        gameObject.GetComponent<Sprite>();
        if(IsPicked)
        {
            go.SetActive(true);
            spr = image.sprite;
            go.GetComponent<Image>().sprite = spr;
            
        }
        else
        {
            go.SetActive(false);
        }
        
        /*
        if(Input.GetMouseButtonDown(1) && IsPicked)
        {
            Inventory.inventory.slots[i].isFull = true;
            Inventory.inventory.slots[i].isSet = true;
            IsPicked = false;
        }
        */
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && IsPicked)
        {

            
            if (Physics.Raycast(ray, out rc))
            {

                if(rc.transform.tag.Contains("Location"))
                {
                    Inventory.inventory.slots[i].go.SetActive(true);
                    Inventory.inventory.slots[i].isSet = true;
                    IsPicked = false;
                    Inventory.inventory.slots[i].isFull = true;
                    Inventory.inventory.slots[i].image.sprite = image.sprite;
                }

                else if (rc.transform.tag == "Usable")
                {
                    Debug.Log(tag);
                    Debug.Log(rc.transform.gameObject.GetComponent<Interactable>().tag);
                    //if (rc.transform.gameObject.GetComponent<Interactable>())
                    //{
                    //    if(rc.transform.gameObject.GetComponent<Interactable>().tag == Inventory.inventory.slots[i].tag)
                    //    {
                    if (tag == rc.transform.gameObject.GetComponent<Interactable>().tag)
                    {
                        rc.transform.gameObject.GetComponent<Interactable>().SendMessage("Clicked");

                        //Destroy(gameObject);
                        Inventory.inventory.slots[i].go.SetActive(false);
                        Inventory.inventory.slots[i].isSet = false;
                        IsPicked = false;
                        Inventory.inventory.slots[i].isFull = false;
                        
                        //inventory test
                        SaveData.isInvSlotFull[i] = false;
                        SaveData.isInvSlotSet[i] = false;
                        SaveData.InvSlotTag[i] = "";
                        SaveData.InvSlotSprite[i] = null;
                        TheSaveManager.Save();
                    }
                    //}
                    //}
                }
                //Debug.Log(rc.transform.tag);
                if (rc.transform.tag == "Pickable")
                {
                    //do stuff
                }
            }
            
        }
    }
}
