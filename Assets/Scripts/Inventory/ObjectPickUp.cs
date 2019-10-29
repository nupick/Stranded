using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPickUp : MonoBehaviour
{
    public Sprite Image;
    //SaveManager sv = GameObject.Find("SaveManager").GetComponent < SaveManager>();
    public string tag;
    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        switch (gameObject.name)
        {
            case ("Gasoline"):
                gameObject.SetActive(!SaveData.isGasolinePicked);
                break;

            case ("Fuse"):
                gameObject.SetActive(!SaveData.isFusePicked);
                break;

            case ("Gear"):
                gameObject.SetActive(!SaveData.isGearPicked);
                break;

            case ("Switch1"):
                //gameObject.SetActive(!SaveData.isSwitch1Picked);
                break;

            case ("Backpack"):
                gameObject.SetActive(!SaveData.isBackpackPicked);
                break;
            case ("Switch2"):
                gameObject.SetActive(!SaveData.isSwitch2Picked);
                break;
            case ("Key"):
                gameObject.SetActive(!SaveData.isKeyPicked);
                break;

        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 7; i++)
            {
                if (!Inventory.inventory.slots[i].isFull)
                {
                    source.clip = clip;
                    source.Play();
                    gameObject.SetActive(false);
                    Inventory.inventory.slots[i].Image = Image;
                    Inventory.inventory.slots[i].isFull = true;
                    Inventory.inventory.slots[i].isSet = true;
                    Inventory.inventory.slots[i].tag = tag;

                    SaveData.isInvSlotFull[i] = true;
                    SaveData.isInvSlotSet[i] = true;
                    SaveData.InvSlotTag[i] = tag;
                    SaveData.InvSlotSprite[i] = Image.name;
                    TheSaveManager.Save();

                    if (gameObject.name == "Gasoline")
                    {
                        SaveData.isGasolinePicked = true;
                        TheSaveManager.Save();
                    }
                    else if (gameObject.name == "Key")
                    {
                        SaveData.isKeyPicked = true;
                        TheSaveManager.Save();
                    }
                    else if (gameObject.name == "Backpack")
                    {
                        SaveData.isBackpackPicked = true;
                        TheSaveManager.Save();
                    }
                    else if (gameObject.name == "Fuse")
                    {
                        SaveData.isFusePicked = true;
                        TheSaveManager.Save();
                    }
                    else if (gameObject.name == "Switch1")
                    {
                        SaveData.isSwitch1Picked = true;
                        SaveData.firstTimeTangram = false;
                        TheSaveManager.Save();
                    }
                    else if (gameObject.name == "Gear")
                    {
                        SaveData.isGearPicked = true;
                        TheSaveManager.Save();
                    }
                    else if (gameObject.name == "Switch2")
                    {
                        SaveData.isSwitch2Picked = true;
                        TheSaveManager.Save();
                    }


                    gameObject.SetActive(false);

                    Debug.Log(gameObject.name);





                    break;
                }

            }
        }
    }

    public void PickUp()
    {
        for (int i = 0; i < 7; i++)
        {
            if (!Inventory.inventory.slots[i].isFull)
            {
                //gameObject.SetActive(false);
                Inventory.inventory.slots[i].Image = Image;
                Inventory.inventory.slots[i].isFull = true;
                Inventory.inventory.slots[i].isSet = true;
                Inventory.inventory.slots[i].tag = tag;

                SaveData.isInvSlotFull[i] = true;
                SaveData.isInvSlotSet[i] = true;
                SaveData.InvSlotTag[i] = tag;
                SaveData.InvSlotSprite[i] = Image.name;
                TheSaveManager.Save();

                if (gameObject.name == "Gasoline")
                {
                    SaveData.isGasolinePicked = true;
                    TheSaveManager.Save();
                }
                else if (gameObject.name == "Key")
                {
                    SaveData.isKeyPicked = true;
                    TheSaveManager.Save();
                }
                else if (gameObject.name == "Backpack")
                {
                    SaveData.isBackpackPicked = true;
                    TheSaveManager.Save();
                }
                else if (gameObject.name == "Fuse")
                {
                    SaveData.isFusePicked = true;
                    TheSaveManager.Save();
                }
                else if (gameObject.name == "Switch1")
                {
                    SaveData.isSwitch1Picked = true;
                    TheSaveManager.Save();
                }
                else if (gameObject.name == "Gear")
                {
                    SaveData.isGearPicked = true;
                    TheSaveManager.Save();
                }
                else if (gameObject.name == "Switch2")
                {
                    SaveData.isSwitch2Picked = true;
                    TheSaveManager.Save();
                }


                //gameObject.SetActive(false);

                Debug.Log(gameObject.name);





                break;
            }
        }

        


    }

}
