using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPuzzleTest : MonoBehaviour {
    public int CollisionDetector = 0;
    public int GearCollisionDetector = 0;
    Vector3 initPos;

    public bool isPicked = false;

    GameObject testName;

    public AudioSource source;
    public AudioClip clip;

    public Collider shutCollider;

    bool test = false;

    [SerializeField] float maxDistance;

    public GearsPuzzleManagerTest manager;
	// Use this for initialization
	void Start () {
        initPos = gameObject.transform.position;
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Debug.Log(GearCollisionDetector);
        if (isPicked)
        {
            GetComponent<GearPuzzleConnection>().isConnected = false;
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 1.5f, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
            gameObject.GetComponent<Renderer>().materials[1].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 0.7f);
            gameObject.GetComponent<Renderer>().materials[0].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 0.7f);
            gameObject.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            //GetComponentInChildren<SphereCollider>().enabled = false;
            GetComponent<GearPuzzleConnection>().oddOrEven = null;
        }
        else
        {
            //GetComponentInChildren<SphereCollider>().enabled = true;
        }
        if(CollisionDetector < 0)
        {
            CollisionDetector = 0;
        }
        if (GearCollisionDetector < 0)
        {
            GearCollisionDetector = 0;
        }
        if (CollisionDetector > 1)
        {
            if (isPicked)
            {
                isPicked = true;
            }
            else
            {
                isPicked = true;
            }
            
            test = true;
        }
        else
        {
            //isPicked = true;
        }
    }
    void Update()
    {
        if (isPicked)
        {
            GetComponent<GearPuzzleConnection>().isConnected = false;
           
            shutCollider.enabled = false;
        }
        else
        {
            shutCollider.enabled = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Gears Slot")
        {
                CollisionDetector++;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Gears Slot")
        {

                CollisionDetector--;
                //CollisionDetector--;
        }
    }

    void OnTriggerStay (Collider col)
    {
        testName = col.gameObject;
        if (CollisionDetector == 1)
        {
            //Debug.Log(new Vector2(transform.position.x - testName.transform.position.x, transform.position.z - testName.transform.position.z).magnitude);

        }


    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.tag =="Gears")
        {
            GearCollisionDetector++;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Gears")
        {
            GearCollisionDetector--;
        }
    }
    void OnCollisionStay(Collision col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "Gears")
        {
            //GearCollisionDetector  = 1;
        }
    }

    void OnMouseOver()
    {
        //Debug.Log("testc");
        if (Input.GetMouseButtonDown(0))
        {
            //shutCollider.enabled = false;
            if (!isPicked)
            {
                if (manager.pickedGear == "")
                {
                    isPicked = true;
                    manager.pickedGear = gameObject.name;
                    //CollisionDetector--;
                }
                //CollisionDetector = 0;
            }
            
            else
            {
                if (CollisionDetector <= 1)
                {
                    if(GearCollisionDetector <= 1)
                    {
                        if (new Vector2(transform.position.x - testName.transform.position.x, transform.position.z - testName.transform.position.z).magnitude < maxDistance)
                        {
                            //CollisionDetector = 1;

                            transform.position = new Vector3(testName.transform.position.x, testName.transform.position.y + 0.5f, testName.transform.position.z);
                            Debug.Log(CollisionDetector);

                            manager.pickedGear = "";
                            isPicked = false;
                                gameObject.GetComponent<Renderer>().materials[1].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 1f);
                                gameObject.GetComponent<Renderer>().materials[0].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 1f);
                                gameObject.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;

                                
                                
                                source.clip = clip;
                                source.Play();

                                
                            
                            
                        }
                    }
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            //shutCollider.enabled = true;
        }

        if(Input.GetMouseButtonDown(1))
        {
            isPicked = false;
            CollisionDetector = 0;
            GearCollisionDetector = 0;
            manager.pickedGear = "";
            transform.position = initPos;
            gameObject.GetComponent<Renderer>().materials[1].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 1f);
            gameObject.GetComponent<Renderer>().materials[0].color = new Color(0.4078431f, 0.4470588f, 0.4941176f, 1f);
            gameObject.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;

        }
    }


}
