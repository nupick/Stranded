using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPainting : MonoBehaviour {

    public PaintingPuzzle[] paintings;
    public GameObject box;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        foreach (PaintingPuzzle painting in paintings)
        {
            painting.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        box.GetComponent<BoxCollider>().enabled = true;
    }
}
