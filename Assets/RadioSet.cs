using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RadioSet : MonoBehaviour {

    public Knob[] knobs = new Knob[4];
    public RadioLights[] lights = new RadioLights[3];
    string radioWave;
    public Camera nextcam;
    public Camera curcam;
    public CursorManager cur;

    public GameObject collider;


    public GameObject OldHatch;
    public GameObject NewHatch;

    public AudioSource source;
    public AudioClip clip;
    public AudioClip finishedClip;

    public bool test = true;

    
	// Use this for initialization
	void Start () {

        if(SaveData.isRadioFinished)
        {
            collider.SetActive(false);
            OldHatch.SetActive(false);
            NewHatch.SetActive(true);
        }
        else
        {
            collider.SetActive(true);
            OldHatch.SetActive(true);
            NewHatch.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(SaveData.isThroneOn)
        {
            lights[0].turnedON = true;
        }

        if (SaveData.isCrownOn)
        {
            lights[1].turnedON = true;
        }

        if (SaveData.isRavenOn)
        {
            lights[2].turnedON = true;
        }
    }
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            test = true;
            source.clip = clip;
            source.Play();
            radioWave = "";
            foreach (Knob knob in knobs)
            {
                radioWave = radioWave + knob.position.ToString();
            }
            switch (radioWave)
            {
                case "9129":
                    TurnOnLights(lights[0]);
                    SaveData.isThroneOn = true;
                    TheSaveManager.Save();
                    break;
                case "2573":
                    TurnOnLights(lights[1]);
                    SaveData.isCrownOn = true;
                    TheSaveManager.Save();
                    break;
                case "4518":
                    TurnOnLights(lights[2]);
                    SaveData.isRavenOn = true;
                    TheSaveManager.Save();
                    break;
            }
            for (int i = 0; i < 3; i++)
            {
                //test[0] = lights[i].turnedON;
                if (!lights[i].turnedON)
                {
                    test = false;
                    break;
                }
                Debug.Log(test);

            }
            if (test)
            {
                //new InSceneMovement().AutomaticMovement(curcam, nextcam, cur);
                StartCoroutine(radioSolve());
                OldHatch.SetActive(false);
                NewHatch.SetActive(true);
            }
            
                

            //Debug.Log(radioWave);

        }

    }
    public void TurnOnLights(RadioLights light)
    {
        
        light.mat.EnableKeyword("_EMISSION");
        light.turnedON = true;
    }

    IEnumerator radioSolve()
    {
        ///SOUND EFFECT HERE
        ///
        source.clip = finishedClip;
        source.Play();
        yield return new WaitForSeconds(1f);
        SaveData.isRadioFinished = true;
        TheSaveManager.Save();
        new InSceneMovement().AutomaticMovement(curcam, nextcam, cur);
        collider.SetActive(false);
    }
}
