using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasolinemanager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(SaveData.isBackpackPicked)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
