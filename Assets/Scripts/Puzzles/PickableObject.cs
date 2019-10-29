using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class PickableObject : MonoBehaviour {
    public int xPosForw;
    public int yPosForw;
    public bool isPicked;
    public bool Outside = false;
    Vector3 beginningPosition;


    /// <summary>
    public int AA;
    public int BB;
    public int CC;
    public int DD;
    /// </summary>
    bool Puttable = false;
    public bool PutDown;

    Ray ray;
    RaycastHit raycast;

    public AudioSource source;
    public AudioClip clip;

    // Use this for initialization
    void Start()
    {

        beginningPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Puttable);
        //Debug.Log(BoardManager.boardManager.layout[0].rows[1].GetType());
        if (isPicked)
        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -0.03f);
            //gameObject.transform.GetComponent<MeshCollider>().enabled = false;
        }
    }

    void OnMouseOver()
    {
        //Debug.Log("WE DOIN' IT BOIS");
        if (Input.GetMouseButtonDown(0))
        {
            if (isPicked && Puttable)
            {
                //Debug.Log("Picked");
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //gameObject.transform.GetComponent<BoxCollider>().enabled = false;

                foreach (BoxCollider bc in transform.GetComponents<BoxCollider>())
                {
                    bc.enabled = false;
                }

                if (Physics.Raycast(ray, out raycast))
                {
                    //Debug.Log(raycast.transform.tag);
                    if (raycast.transform.tag == "Usable")
                    {
                        //Debug.Log(LightManager.lightManager.rows[0].fuses[0]);
                        //Debug.Log(raycast.transform.GetComponent<FuseSlot>());
                        //int a = Array.IndexOf(LightManager.lightManager.rows, raycast.transform.GetComponent<FuseSlot>());
                       


                        gameObject.transform.position = new Vector3(raycast.transform.position.x, raycast.transform.position.y, -0.5f);

                        source.clip = clip;
                        source.Play();
                        
                        //Debug.Log(raycast.transform.name);
                        rowsandcolumns(raycast.transform.name, out AA,out BB, out CC,out DD);
                        //Debug.Log(BoardManager.boardManager.layout[0].rows[0].name);
                        //Debug.Log(raycast.transform.name);
                        isPicked = false;
                        PutDown = true;

                    }
                }
                foreach (BoxCollider bc in transform.GetComponents<BoxCollider>())
                {
                    bc.enabled = true;
                }
                //gameObject.transform.GetComponent<BoxCollider>().enabled = true;





                //Debug.Log(BoardManager.boardManager.layout[0].rows[2].name);
            }
            else if (PutDown)
            {
                //Debug.Log(Input.mousePosition);
                BoardManager.boardManager.TurnOffLights(AA, BB, CC, DD);
                isPicked = true;
                PutDown = false;
            }
            else
            {
                isPicked = true;
            }


        }



        if (Input.GetMouseButtonDown(1))
        {
            //if (BoardManager.boardManager.row[AA].NumOfCablesDup )
            if (PutDown)
            {
                BoardManager.boardManager.TurnOffLights(AA, BB, CC, DD);
                PutDown = false;
            }
            gameObject.transform.position = beginningPosition;

            source.clip = clip;
            source.Play();

            isPicked = false;
        }

    }

    void OnTriggerStay(Collider col)
    {
        //Debug.Log(col.transform.name);
        if (col.transform.tag == "Pickable")
        {
            Puttable = false;
        }

        if (col.transform.tag == "Outside")
        {
            Puttable = false;
        }


    }

    
    void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Pickable")
        {
            Puttable = true;
        }

        if (col.transform.tag == "Outside")
        {
            Puttable = true;
        }


    }







    //Searching the 2D Array of Slots to find the slot we are on


    struct rowsNcolumns
    {
        public int row;
        public int column;
        public string name;
        
    }

    private rowsNcolumns rowsandcolumns(string SlotName, out int atest,out int btest,out int ctest,out int dtest)
    {
        int a = 0;
        int b = 0;

        atest = b;
        btest = a;
        ctest = b + yPosForw;
        dtest = a + xPosForw;
        for (int i = 0; i < 8; i++)
        {
            b = i;
            for (int j = 0; j < 9; j++)
            {
                a = j;
                if (BoardManager.boardManager.layout[i].rows[j].name == SlotName)
                {
                    Debug.Log(yPosForw + " " + xPosForw);
                    Debug.Log(a + " " + b);

                    BoardManager.boardManager.TurnOnLights(b,a,b+yPosForw,a+xPosForw);

                    atest = b;
                    btest = a;
                    ctest = b + yPosForw;
                    dtest = a + xPosForw;
                    break;
                    
                }   
                

            }
            
        }
        var result = new rowsNcolumns
        {
            row = a,
            column = b
        };



        return result;

    }





}
