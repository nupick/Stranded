using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenManager : MonoBehaviour {

    public Camera cam1;
    public Camera cam2;
    public Camera camclock;

    public GameObject col1;
    public GameObject col2;
	// Use this for initialization
	void Start () {
        if(SaveData.isGearsFinished)
        {
            if (SaveData.firstTimeGears)
            {
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                camclock.gameObject.SetActive(true);
                SaveData.firstTimeGears = false;
            }
            else
            {
                cam1.gameObject.SetActive(true);
                cam2.gameObject.SetActive(false);
                camclock.gameObject.SetActive(false);
            }
        }
        else
        {
            cam1.gameObject.SetActive(false);
            camclock.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
        }

        if (SaveData.isGearInserted)
        {
            col1.SetActive(true);
            col2.SetActive(false);
        }
        else
        {
            col1.SetActive(false);
            col2.SetActive(true);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
