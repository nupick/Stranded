using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramPuzzle : MonoBehaviour
{
    public bool isPicked;

    public Vector3 target;
    public Vector3 initPos;

    public float yPos;
    
    public bool PutDown;
    public GameObject rightSlot;
    public bool rightPlace;

    Ray ray;
    RaycastHit raycast;

    TangramPuzzle next;

    public AudioSource source;
    public AudioClip clip;

    // Use this for initialization
    void Start()
    {
        initPos = transform.position;
        //xPos = transform.position.x;
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPicked)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = 3.031f;
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
                    if (raycast.transform.tag == "Tangram Slot")
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
                foreach (MeshCollider bc in transform.GetComponents<MeshCollider>())
                {
                    bc.enabled = false;
                }

                if (Physics.Raycast(ray, out raycast))
                {
                    Vector3 test = raycast.transform.position;

                    if (raycast.transform.tag == "Tangram Slot" && raycast.transform.name == rightSlot.name)
                    {
                        Debug.Log(raycast.transform.name);
                        if (raycast.transform.name == rightSlot.name)
                        {
                            gameObject.transform.position = new Vector3(raycast.transform.position.x, yPos, raycast.transform.position.z);
                        }
                        source.clip = clip;
                        source.Play();
                        isPicked = false;
                        PutDown = true;

                    }
                    else if (raycast.transform.tag == "Tangram")
                    {
                        next = raycast.transform.GetComponent<TangramPuzzle>();
                        isPicked = false;
                        transform.position = initPos;
                        foreach (MeshCollider bc in transform.GetComponents<MeshCollider>())
                        {
                            bc.enabled = true;
                        }
                        next.isPicked = true;
                    }
                }
                foreach (MeshCollider bc in transform.GetComponents<MeshCollider>())
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
        gos = GameObject.FindGameObjectsWithTag("Tangram Slot");

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
