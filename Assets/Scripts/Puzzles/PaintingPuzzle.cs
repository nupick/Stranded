using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPuzzle : MonoBehaviour {
    public bool isPicked;

    public Vector3 target;
    
    public float xPos;

    public bool PutDown;
    public GameObject rightSlot;
    public bool rightPlace;

    Ray ray;
    RaycastHit raycast;

    PaintingPuzzle next;

    public AudioSource source;
    public AudioClip clip;
    // Use this for initialization
    void Start ()
    {
        xPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (isPicked)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.x = -35.81f;
            transform.position = target;      

        }
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (isPicked)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] raycasts = Physics.RaycastAll(ray);
                foreach (RaycastHit raycast in raycasts)
                {
                    if (raycast.transform.tag == "Painting Slot")
                    {
                        if (raycast.transform.name == rightSlot.transform.name)
                        {
                            rightPlace = true;
                        }
                        else
                        {
                            rightPlace = false;
                        }
                    }
                }
                foreach (BoxCollider bc in transform.GetComponents<BoxCollider>())
                {
                    bc.enabled = false;
                }

                if (Physics.Raycast(ray, out raycast))
                {
                    Vector3 test = raycast.transform.position;

                    source.clip = clip;
                    source.Play();
                    if (raycast.transform.tag == "Painting Slot")
                    {
                        gameObject.transform.position = new Vector3(xPos, raycast.transform.position.y, raycast.transform.position.z);
                        isPicked = false;
                        PutDown = true;

                    }
                    else if (raycast.transform.tag == "Painting")
                    {

                        next = raycast.transform.GetComponent<PaintingPuzzle>();
                        isPicked = false;
                        next.isPicked = true;
                        transform.position = test;
                    }
                }
                foreach (BoxCollider bc in transform.GetComponents<BoxCollider>())
                {
                    bc.enabled = true;
                }
            }
            else if (PutDown)
            {
                isPicked = true;
                PutDown = false;
            }
            else
            {

                rightPlace = false;
                isPicked = true;
            }


        }
    }

    public GameObject FindClosestSlot()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Painting Slot");

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


}
