using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseManager : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;

    public GameObject fuse;
    public GameObject gear;
    // Use this for initialization
    void Start()
    {
        if (SaveData.isKeyInserted)
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
            //fuse.gameObject.SetActive(true);
            //gear.gameObject.SetActive(true);
        }
        else
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        //if(!SaveData.isGearPicked)
        //{
        //    gear.SetActive(true);
        //}

        //gear.SetActive(!SaveData.isGearPicked);
        //fuse.SetActive(!SaveData.isFusePicked);
    }
}

