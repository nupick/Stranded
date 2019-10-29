using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour {
    public interSceneMovement inter;
	// Use this for initialization
	void Start () {
        StartCoroutine(Wait());
        StartCoroutine(TheEndAnim());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TheEndAnim()
    {
        yield return new WaitForSeconds(3);
        inter.DoIt();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
}
