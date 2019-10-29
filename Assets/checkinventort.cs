using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkinventort : MonoBehaviour {
    public GameObject inventory;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        inventory.SetActive(SaveData.isInvOn);
	}
}
