using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour {
    public interSceneMovement inter;
	// Use this for initialization
	void Start () {
        //Screen.SetResolution(Screen.width, Screen.height, true);
        StartCoroutine(Play());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Play()
    {
        yield return new WaitForSeconds(4);
        inter.DoIt();


    }
}
