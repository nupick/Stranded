using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour {
    float rotation = 57f;
    public int position = 0;
    public Material mat;

    public AudioSource source;
    public AudioClip clip;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnMouseOver()
    {
        //Debug.Log(position);
        if (Input.GetMouseButtonDown(0))
        {
            rotation += 28;
            source.clip = clip;
            source.Play();
            gameObject.transform.Rotate(new Vector3(0, 0, 28));
            position++;
            if(transform.localEulerAngles.z >= 320)
            {
                gameObject.transform.localEulerAngles = new Vector3(0, -60.9f, 55f);
                position = 0;
            }
        }
        
    }
}
