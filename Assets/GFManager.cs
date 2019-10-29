using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFManager : MonoBehaviour {


    public GameObject go;

    public Material mat;

    public GameObject fuse;
    // Use this for initialization
    void Start() {

        go.SetActive(SaveData.isFuseInserted);


        if(SaveData.isElevOn)
        {
            mat.EnableKeyword("_EMISSION");
            fuse.SetActive(false);
        }
        else
        {
            mat.DisableKeyword("_EMISSION");
            fuse.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
