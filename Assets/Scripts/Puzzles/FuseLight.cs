using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseLight : MonoBehaviour {

    public Material LitMat;
    public Material NormMat;
    public bool isOn;

    public int NumOfCablesDup;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TurnOn()
    {
        gameObject.transform.GetComponent<Renderer>().material = LitMat;
        isOn = true;
    }

    public void TurnOff()
    {
        gameObject.transform.GetComponent<Renderer>().material = NormMat;
        isOn = false;
    }
}
