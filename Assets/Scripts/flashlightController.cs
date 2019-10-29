using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightController : MonoBehaviour {

    public float CamZ = 5f;
    Vector3 mousePosition;
    public Camera cam;
    Ray ray;
    RaycastHit rayhit;
    //public GameObject flashlight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.SetActive(SaveData.isInvOn);
        if (!SaveData.LightSwitch)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            //transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, CamZ));
            //Debug.Log(mousePosition.ToString());
            //transform.position = mousePosition;
            transform.LookAt(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, CamZ)));
        }
        else
        {
            gameObject.SetActive(false);
        }

       
    }
}
