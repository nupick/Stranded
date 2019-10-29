using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusePicking : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.SetActive(!SaveData.isFusePicked);
	}


}
