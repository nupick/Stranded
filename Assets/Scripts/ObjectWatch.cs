using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWatch : MonoBehaviour {

    public GameObject[] current;
    public GameObject[] next;

    public AudioSource source;
    public AudioClip clip;
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
            source.clip = clip;
            source.Play();
            foreach(GameObject go in current)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in next)
            {
                go.SetActive(true);
            }
            
        }
    }
}
