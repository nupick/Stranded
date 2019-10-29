using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndGoBack : MonoBehaviour {
    public Camera cam;
    public Camera nextcam;
    public CursorManager cur;
    public GameObject currentGO;
    public GameObject nextGO;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            new InSceneMovement().AutomaticMovement(cam, nextcam, cur);
            currentGO.SetActive(false);
            currentGO.SetActive(true);
        }
    }
}
