using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmision : MonoBehaviour {


    public Material mat;
    // Use this for initialization
    //public float emission = Mathf.PingPong(Time.deltaTime, 1.0f);
     //Color basecolor = Color.white;

    //Color finalcolor = Color.white* Mathf.LinearToGammaSpace(1);
	void Start ()
    {
        mat.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update ()
    {
        //mat.SetColor("_EmissionColor", Color.red);

    }
}
