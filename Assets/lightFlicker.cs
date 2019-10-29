using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour {
    bool flick = false;
    public bool isElecOn = false;
    public float speed;
    public GameObject parent;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Flick());
	}
	
	// Update is called once per frame
	void Update ()
    {
        isElecOn = SaveData.LightSwitch;
    }

    IEnumerator Flick()
    {
            while (flick == false)
            {
                if (isElecOn)
                {
                    gameObject.GetComponent<Light>().color = new Color(gameObject.GetComponent<Light>().color.r - speed * Time.deltaTime, gameObject.GetComponent<Light>().color.g, gameObject.GetComponent<Light>().color.b);
                    parent.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(parent.GetComponent<Renderer>().material.color.r - (speed * Time.deltaTime) * 10, 0, 0));
                    yield return new WaitForFixedUpdate();
                    if (gameObject.GetComponent<Light>().color.r <= 0)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            while (flick == true)
            {
                if (isElecOn)
                {
                    gameObject.GetComponent<Light>().color = new Color(gameObject.GetComponent<Light>().color.r + speed * Time.deltaTime, gameObject.GetComponent<Light>().color.g, gameObject.GetComponent<Light>().color.b);
                    parent.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(parent.GetComponent<Renderer>().material.color.r + (speed * Time.deltaTime) * 10, 0, 0));
                    yield return new WaitForFixedUpdate();
                    if (gameObject.GetComponent<Light>().color.r >= 1)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
        }
            //else if (flick == true)
            //{
            //    gameObject.GetComponent<Light>().color = new Color(gameObject.GetComponent<Light>().color.r + speed * Time.deltaTime, gameObject.GetComponent<Light>().color.g, gameObject.GetComponent<Light>().color.b);
            //}

            yield return new WaitForSeconds(1);
            flick = !flick;
        
            StartCoroutine(Flick());
        
    }
}
