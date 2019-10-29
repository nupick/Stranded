using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSceneMovement : MonoBehaviour {


    public CursorManager cur = new CursorManager();
    public Camera CurrentCam;
    public Camera NextCamera;
	
	// Update is called once per frame
	void OnMouseDown()
    {
        CurrentCam.gameObject.SetActive(false);
        NextCamera.gameObject.SetActive(true);
        cur.cam = NextCamera;
    }
    public void AutomaticMovement(Camera current , Camera nex,CursorManager cursorManager)
    {
        current.gameObject.SetActive(false);
        nex.gameObject.SetActive(true);
        cursorManager.cam = nex;
    }
}
