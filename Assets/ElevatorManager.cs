using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour {


    public GameObject elevator;

    public GameObject GoUp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!SaveData.isElevOn)
        {
            foreach(interSceneMovement go in gameObject.GetComponentsInChildren<interSceneMovement>())
            {
                go.enabled = false;
                go.gameObject.GetComponent<BoxCollider>().enabled = false;
                elevator.GetComponent<Renderer>().materials[10].DisableKeyword("_EMISSION");
            }
            GoUp.GetComponent<BoxCollider>().enabled = false;
            GoUp.GetComponent<interSceneMovement>().enabled = false;

        }
        else
        {
            foreach (interSceneMovement go in gameObject.GetComponentsInChildren<interSceneMovement>())
            {
                go.enabled = true;
                go.gameObject.GetComponent<BoxCollider>().enabled = true;

                elevator.GetComponent<Renderer>().materials[10].EnableKeyword("_EMISSION");
            }
            GoUp.GetComponent<BoxCollider>().enabled = true;
            GoUp.GetComponent<interSceneMovement>().enabled = true;
        }
	}
}
