using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        foreach (Material mat in gameObject.GetComponent<MeshRenderer>().materials)
        {
            mat.EnableKeyword("_EMISSION");
        }
    }
}
