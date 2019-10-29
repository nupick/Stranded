using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearInteraction : Interactable {

    [SerializeField] interSceneMovement inter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Clicked()
    {
        SaveData.isGearInserted = true;
        //TheSaveManager.Save();
        inter.DoIt();
    }
}
