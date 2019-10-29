using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteraction : Interactable {

    public GameObject switch1;
    public GameObject switch2;

    public AudioSource source;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
		if (tag=="Switch1")
        {
            if(SaveData.isSwitch1Inserted)
            {
                Destroy(gameObject);
            }
        }
        if (tag == "Switch2")
        {
            if (SaveData.isSwitch2Inserted)
            {
                Destroy(gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Clicked()
    {
        if(tag == "Switch1")
        {
            switch1.SetActive(true);
            gameObject.SetActive(false);
            SaveData.isSwitch1Inserted = true;
        }
        if(tag == "Switch2")
        {
            switch2.SetActive(true);
            gameObject.SetActive(false);
            SaveData.isSwitch2Inserted = true;
        }
        TheSaveManager.Save();
        source.clip = clip;
        source.Play();
    }
}
