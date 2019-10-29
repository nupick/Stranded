using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   void Start()
    {
        StartCoroutine(CheckInventory());
        gameObject.SetActive(SaveData.isInvOn);
        //Debug.Log(SaveData.isInvSlotFull[0]);
        //Debug.Log("Test");
        //Object.DontDestroyOnLoad(gameObject);
    }
    public static Inventory inventory { get; private set; }

    public Slots[] slots = new Slots[7];
    
    void Update()
    {
        //gameObject.SetActive(SaveData.isInvOn);
        //Debug.Log(SaveData.isInvOn);
        //Debug.Log(SaveData.isGearPicked);
    }

    private void Awake()
    {
        //DontDestroyOnLoad(transform.parent);
        gameObject.SetActive(SaveData.isInvOn);
        inventory = this;
        
        

    }
    IEnumerator CheckInventory()
    {
        yield return 0;
        for (int i = 0; i < 6; i++)
        {
            //Debug.Log(SaveData.InvSlotSprite[0]);
            //Debug.Log(SaveData.isInvSlotFull[0]);
            slots[i].isFull = SaveData.isInvSlotFull[i];
            slots[i].isSet = SaveData.isInvSlotSet[i];
            slots[i].tag = SaveData.InvSlotTag[i];
            slots[i].Image = Resources.Load<Sprite>(SaveData.InvSlotSprite[i]) ;

             
        }
    }
}
