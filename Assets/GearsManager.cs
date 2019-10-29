using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsManager : MonoBehaviour {
    public Camera cam1;
    public Camera cam2;

    public GameObject gears1;
    public GameObject gears2;

    public GameObject inventory;
	// Use this for initialization
	void Start () {

        if(!SaveData.isGearInserted)
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
            gears1.SetActive(true);
            gears2.SetActive(false);

            inventory.SetActive(true);
        }
        else
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
            gears1.SetActive(false);
            gears2.SetActive(true);

            inventory.SetActive(false);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
