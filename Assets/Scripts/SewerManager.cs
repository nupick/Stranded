using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerManager : MonoBehaviour {

    public GameObject rush1;
    public GameObject rush2;

    public AudioSource source;
    public AudioClip clip;

    public GameObject collidr;
	// Use this for initialization
	void Start ()
    {
        if (SaveData.isRushHourFinished)
        {
            rush1.gameObject.SetActive(false);
            rush2.gameObject.SetActive(true);
            collidr.SetActive(false);
        }
        else
        {
            rush1.gameObject.SetActive(true);
            rush2.gameObject.SetActive(false);
            collidr.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
