using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInteraction : Interactable
{
    public AudioSource source;
    public AudioSource source2;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Clicked()
    {
        source.clip = clip;
        source.Play();
        StartCoroutine(Wait(clip.length));
        gameObject.SetActive(false);
        SaveData.LightSwitch = true;
        source2.volume = 1;
        TheSaveManager.Save();
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSecondsRealtime(t);
    }
}
