using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour {


    public interSceneMovement inter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoIt()
    {

        //inter.scn = SaveData.levelID;
        inter.DoIt();
    }
}
