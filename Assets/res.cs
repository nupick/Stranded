using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class res : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        
	}
	
	// Update is called once per frame
	void Update () {


        Debug.Log(Screen.currentResolution);

    }
}
