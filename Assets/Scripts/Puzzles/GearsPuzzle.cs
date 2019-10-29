using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsPuzzle : MonoBehaviour
{
    public float rotation;

    public bool finished;

    public float RotationSpeed;

    public Material selected;
    Renderer rend;

    public GameObject rot1;
    public GameObject rot2;

    Quaternion initRot;

    public bool initgear;
    public bool isPicked;
    
    public Vector3 target;
    public Vector3 initPos;
    Collider test;

    public bool puttable;

    public bool inPlace;
    int num = 0;

    public bool Connected = false;


    public float yPos;

    public bool PutDown;
    public GameObject rightSlot;
    public bool rightPlace;

    Ray ray;
    RaycastHit raycast;

    GearsPuzzle next;

    // Use this for initialization
    void Start()
    {
        
        initPos = transform.position;
        yPos = transform.position.y;
        inPlace = false;
        puttable = true;
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicked)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = 1.5f;
            transform.position = target;


            gameObject.GetComponent<Renderer>().materials[1].color = new Color(0.4078431f, 0.4470588f, 0.4941176f,0.7f);
            gameObject.GetComponent<Renderer>().materials[0].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 0.7f);
            gameObject.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;




        }
        else
        {
            //rend.sharedMaterial = materials[0];
            if (!initgear)
            {
                gameObject.GetComponent<Renderer>().materials[1].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 1f);
                gameObject.GetComponent<Renderer>().materials[0].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 1f);
                gameObject.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
            }

        }
        if (num<0)
        {
            num = 0;
        }

    }
    void FixedUpdate()
    {
        Debug.Log(num);
        if (finished)
        {
            transform.Rotate(0, 0, RotationSpeed, Space.Self);
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

                foreach (CapsuleCollider bc in transform.GetComponents<CapsuleCollider>())
                {
                    bc.enabled = false;
                    Debug.Log("Test");

                }

                if (Physics.Raycast(ray, out raycast))
                {

                    Vector3 test = raycast.transform.position;
                    if (raycast.transform.tag == "Gears Slot" && num < 3 && puttable)
                    {

                        if (num < 3)
                        {

                            gameObject.transform.position = new Vector3(raycast.transform.position.x, yPos, raycast.transform.position.z);

                            inPlace = true;

                        }
                        isPicked = false;
                        PutDown = true;

                    }
                    else if (raycast.transform.tag == "Gears")
                    {
                        //Debug.Log(raycast.transform.name);
                        next = raycast.transform.GetComponent<GearsPuzzle>();
                        isPicked = false;
                        transform.position = initPos;
                        foreach (CapsuleCollider bc in transform.GetComponents<CapsuleCollider>())
                        {
                            bc.enabled = true;
                        }

                        next.isPicked = true;
                        next.puttable = true;

                    }

                    else
                    {
                        num = 0;
                    }
                }
                foreach (CapsuleCollider bc in transform.GetComponents<CapsuleCollider>())
                {
                    bc.enabled = true;
                    num--;
                }
            }
            else if (PutDown)
            {
                if (!initgear)
                {
                    isPicked = true;
                    PutDown = false;
                    inPlace = false;
                    Connected = false;
                    transform.rotation = initRot;
                }


            }
            else
            {
                if (!initgear)
                {
                    rightPlace = false;
                    isPicked = true;
                    inPlace = false;
                    Connected = false;
                    transform.rotation = initRot;

                }

            }


        }
    }

    public GameObject FindClosestSlot()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Gears Slot");

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
    void OnTriggerEnter(Collider col)
    {
        num++;
        //Debug.Log(num);

        if (PutDown)
        {
            if (col.transform.tag == "Gears Slot")
            {
                Debug.Log("TEST!!");
                if (col.transform.name == rot1.transform.name)
                {
                    transform.Rotate(0, 0, 10, Space.Self);
                }
                if (col.transform.name == rot2.transform.name)
                {
                    transform.Rotate(0, 0, 13, Space.Self);
                }
                //Debug.Log(col.transform.name);
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        //if (col.transform.tag == "Gears" && col.transform.GetComponent<GearsPuzzle>().inPlace)
        //{
        //    puttable = false;
        //}
        if (col.transform.tag == "Gears")
        {
            // Debug.Log(col.gameObject.name);
        }
        if (PutDown)
        {
            if (col.transform.GetComponent<GearsPuzzle>() != null)
            {
                if (col.transform.GetComponent<GearsPuzzle>().Connected)
                {
                    Connected = true;
                    if (RotationSpeed == 0)
                    {
                        RotationSpeed = col.transform.GetComponent<GearsPuzzle>().RotationSpeed * -1;
                    }
                }
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        //num--;
        if (col.transform.tag == "Gears")
        {
            puttable = true;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        num++;
        puttable = false;
        if(PutDown)
        {
            if (col.transform.GetComponent<GearsPuzzle>() != null)
            {
                if (col.transform.GetComponent<GearsPuzzle>().Connected)
                {
                    Connected = true;
                    //RotationSpeed = col.transform.GetComponent<GearsPuzzle>().RotationSpeed * -1;
                }
            }
            if (col.transform.tag == "Gears Slot")
            {
                Debug.Log("TEST!");
                if (col.transform.name == rot1.transform.name)
                {
                    transform.Rotate(0, 0, 10, Space.Self);
                }
                if (col.transform.name == rot2.transform.name)
                {
                    transform.Rotate(0, 0, 13, Space.Self);
                }
                //Debug.Log(col.transform.name);
            }


        }
        if (PutDown)
        {
            if (col.transform.tag == "Gears Slot")
            {
                if (col.transform.name == rot1.transform.name)
                {
                    transform.Rotate(0, 0, 10, Space.Self);
                }
                if (col.transform.name == rot2.transform.name)
                {
                    transform.Rotate(0, 0, 13, Space.Self);
                }
                //Debug.Log(col.transform.name);
            }
        }

    }

    void OnCollisionStay(Collision col)
    {

        if (col.transform.tag == "Gears")
        {
            puttable = false;
        }
        //if (col.transform.GetComponent<GearsPuzzle>() != null)
        //{
        //    if (col.transform.GetComponent<GearsPuzzle>().Connected)
        //    {
        //        Connected = true;
        //        if (RotationSpeed == 0)
        //        {
        //            RotationSpeed = col.transform.GetComponent<GearsPuzzle>().RotationSpeed * -1;
        //        }
        //    }
        //}
    }

    void OnCollisionExit(Collision col)
    {
        num--;
        puttable = true;
        if (!initgear)
        {
            Connected = false;
        }

    }

    public void FinishedRotate()
    {
        
    }


}
