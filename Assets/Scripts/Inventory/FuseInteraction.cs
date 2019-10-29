using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseInteraction : Interactable {
    public GameObject fuse;

    public AudioSource source;
    public AudioClip clip;
    public GameObject inScene;

    public GameObject inscene2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(SaveData.isElevOn)
        {
            inScene.SetActive(false);
            inscene2.SetActive(false);
        }
	}

    void Clicked()
    {
        Debug.Log("WOW");
        fuse.SetActive(true);
        SaveData.isFuseInserted = true;
        TheSaveManager.Save();
        source.clip = clip;
        source.Play();
        gameObject.SetActive(false);
    }
}
