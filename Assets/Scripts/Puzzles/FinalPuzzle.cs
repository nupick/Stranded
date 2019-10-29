using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour {
    public GameObject button;
    public GameObject light;
    public FinalPuzzleManager manager;
    public bool set = false;

    public AudioSource source;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(set)
        {
            foreach (BoxCollider bc in gameObject.GetComponents<BoxCollider>())
            {
                bc.enabled = false;
            }
            light.GetComponent<Renderer>().materials[0].SetColor("_EMISSION", new Color(0.02352941f, 1, 0.0470588f, 1));
            light.GetComponent<Renderer>().materials[0].EnableKeyword("_EMISSION");

        }
        else
        {
            //button.transform.Translate(new Vector3(0, 0.02f, 0), Space.World);
            light.GetComponent<Renderer>().materials[0].SetColor("_EMISSION", new Color(0.2745098f, 0.3921568f, 0.2470588f, 1));
            light.GetComponent<Renderer>().materials[0].DisableKeyword("_EMISSION");
        }
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            button.transform.Translate(new Vector3(0, -0.02f, 0), Space.World);
            set = true;
            //button.transform.Translate(new Vector3(0, -0.02f, 0),Space.World);
            manager.connected = true;
            source.clip = clip;
            source.Play();
            manager.buttonName = transform.name;
        }
    }
    
}
