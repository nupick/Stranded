using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSoundManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if(SaveData.LightSwitch)
        {
            gameObject.GetComponent<AudioSource>().volume = 1;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 0;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
