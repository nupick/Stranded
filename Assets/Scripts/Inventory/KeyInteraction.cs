using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : Interactable {

    public interSceneMovement inter;

    public AudioSource source;
    public AudioClip clip;

    public GameObject fuse;
    public GameObject gear;

	// Use this for initialization
	void Start () {
        if(SaveData.isKeyInserted)
        {
            fuse.SetActive(true);
            fuse.SetActive(false);
            gameObject.SetActive(false);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Object tag: " + tag);
        
		
	}

    void Clicked()
    {
        //Debug.Log("WE DID IT");
        SaveData.isKeyInserted = true;

        source.clip = clip;
        source.Play();
        //gameObject.SetActive(false);
        inter.DoIt();
        TheSaveManager.Save();
    }
}
