using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpstairsManager : MonoBehaviour {

    public GameObject screen;
    public GameObject puzzleCam;
    public GameObject screenCam;


    public GameObject Switch1;
    public GameObject Switch2;
	// Use this for initialization
	void Start () {

        if(SaveData.isCircuitFinished)
        {
            screen.SetActive(true);
            puzzleCam.SetActive(false);
            screenCam.SetActive(true);
        }
        else
        {
            screen.SetActive(false);
            puzzleCam.SetActive(true);
            screenCam.SetActive(false);
        }

        if(SaveData.isSwitch1Inserted)
        {
            Switch1.SetActive(true);

        }
        else
        {
            Switch1.SetActive(false);
        }

        if (SaveData.isSwitch2Inserted)
        {
            Switch2.SetActive(true);

        }
        else
        {
            Switch2.SetActive(false);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
