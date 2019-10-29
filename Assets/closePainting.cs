using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closePainting : MonoBehaviour {


    public PaintingPuzzleManager pzl;

    public GameObject box;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        foreach (PaintingPuzzle painting in pzl.paintings)
        {
            painting.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        box.GetComponent<BoxCollider>().enabled = false;
    }
}
