using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewGame : MonoBehaviour {

    public interSceneMovement inter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Startup()
    {
        
        File.Delete(Application.persistentDataPath + "/save.dat");
        //Directory.Delete(Application.persistentDataPath, true);

        inter.DoIt();
    }
}
