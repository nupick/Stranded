using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseSlot : MonoBehaviour {
    public Material LitMat;
    public Material NormMat;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TurnOn()
    {
        gameObject.transform.GetComponent<Renderer>().material = LitMat;
    }

    void TurnOff()
    {
        gameObject.transform.GetComponent<Renderer>().material = NormMat;
    }
}
