using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backtomenu : MonoBehaviour {

    public interSceneMovement inter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            inter.DoIt();
        }
	}


}
