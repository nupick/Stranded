using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOutManager : MonoBehaviour {
    public Light[] lights;
    public Material[] materials;
    public GameObject[] colliders;
    public RadioLights[] radiolights;
    public bool isElecOn;

    public bool isFinished;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        isElecOn = SaveData.LightSwitch;
		if(!isElecOn)
        {
            foreach(Light light in lights)
            {
                light.enabled = false;
            }
            foreach(Material mat in materials)
            {
                mat.DisableKeyword("_EMISSION");
            }
        }
        else
        {
            foreach (Light light in lights)
            {
                light.enabled = true;
            }
            foreach (Material mat in materials)
            {
                mat.EnableKeyword("_EMISSION");
                
            }
            foreach(GameObject go in colliders)
            {
                go.SetActive(false);
            }
        }
        if(SaveData.isThroneOn)
        {
            radiolights[0].mat.EnableKeyword("_EMISSION");
        }
        else
        {
            if (radiolights.Length > 0)
            {
                radiolights[0].mat.DisableKeyword("_EMISSION");
            }
        }
        if (SaveData.isCrownOn)
        {
            if(radiolights.Length > 0)
            {
                radiolights[1].mat.EnableKeyword("_EMISSION");
            }
        }
        else
        {
            if(radiolights.Length > 0)
            {
                radiolights[1].mat.DisableKeyword("_EMISSION");
            }
        }
        if (SaveData.isRavenOn)
        {
            radiolights[2].mat.EnableKeyword("_EMISSION");
        }
        else
        {
            if(radiolights.Length > 0)
            {
                radiolights[2].mat.DisableKeyword("_EMISSION");

            }
        }
    }
}
