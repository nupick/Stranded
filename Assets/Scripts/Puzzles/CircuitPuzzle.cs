using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitPuzzle : MonoBehaviour {

    public bool rotatable;

    public bool connected;
    public GameObject ConnectionFrom;
    public string ConnectionFromName;
    public bool mainlamp;
    public CircuitPuzzleManager manager;
    Collision[] Collisions;
    private MeshCollider dd;

    public AudioSource source;
    public AudioClip clip;

	// Use this for initialization
	void Start ()
    {
        if (!mainlamp)
        {
            rotatable = true;
        }

        dd = transform.GetComponent<MeshCollider>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(mainlamp)
        {
            connected = true;
        }
        if (ConnectionFrom != null)
        {
            if (ConnectionFrom.GetComponent<CircuitPuzzle>().connected == false)
            {
                connected = false;
            }
        }

        if(ConnectionFrom == null)
        {
            if(!mainlamp)
            {
                connected = false;
            }
            
        }
        if (connected)
        {
            if(transform.tag == "Circuit Main")
            {
                gameObject.GetComponent<Renderer>().materials[0].SetColor("_EMISSION", new Color(0.0927F, 0.4852F, 0.2416F, 0.42F));
                gameObject.GetComponent<Renderer>().materials[0].EnableKeyword("_EMISSION");
            }
            else if (transform.tag == "Circuit Lamp")
            {
                gameObject.GetComponent<Renderer>().materials[1].SetColor("_EMISSION", new Color(0.0927F, 0.4852F, 0.2416F, 0.42F));
                gameObject.GetComponent<Renderer>().materials[1].EnableKeyword("_EMISSION");

                gameObject.GetComponent<Renderer>().materials[4].SetColor("_EMISSION", new Color(0.0927F, 0.4852F, 0.2416F, 0.42F));
                gameObject.GetComponent<Renderer>().materials[4].EnableKeyword("_EMISSION");
            }
        }
        else
        {
            if (transform.tag == "Circuit Main")
            {
                gameObject.GetComponent<Renderer>().materials[0].SetColor("_EMISSION", new Color(0.2746493f, 0.5008312f, 0.622f, 1f));
                gameObject.GetComponent<Renderer>().materials[0].DisableKeyword("_EMISSION");
            }
            else if (transform.tag == "Circuit Lamp")
            {
                gameObject.GetComponent<Renderer>().materials[1].SetColor("_EMISSION", new Color(0.2746493f, 0.5008312f, 0.622f, 1f));
                gameObject.GetComponent<Renderer>().materials[1].DisableKeyword("_EMISSION");

                gameObject.GetComponent<Renderer>().materials[4].SetColor("_EMISSION", new Color(0.2746493f, 0.5008312f, 0.622f, 1f));
                gameObject.GetComponent<Renderer>().materials[4].DisableKeyword("_EMISSION");
            }
        }
    }

    void OnMouseOver()
    {
        if (rotatable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (CircuitPuzzle pipe in manager.lamps)
                {
                    pipe.ConnectionFrom = null;
                    if (!pipe.mainlamp)
                    {
                        pipe.connected = false;
                    }
                }
                //dd.enabled = false;
                foreach(MeshCollider col in gameObject.GetComponents<MeshCollider>())
                {
                    col.enabled = false;
                }
                //transform.Rotate(0, 90f, 0, Space.Self);
                //transform.Rotate(0, 90f, 0, Space.World);
                source.clip = clip;
                source.Play();
                StartCoroutine(Rotation(new Vector3(0, 0, 1), 90f, 0.25f));
                



            }
        }
    }

    IEnumerator Rotation(Vector3 axis , float angle , float duration)
    {
        connected = false;
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            rotatable = false;
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;


        }
        transform.rotation = to;
        rotatable = true;
        dd.enabled = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.GetComponent<CircuitPuzzle>().connected)
        {
            if (col.transform.GetComponent<CircuitPuzzle>().connected)
            {
                if (ConnectionFrom == null)
                {
                    ConnectionFrom = col.transform.gameObject;
                    ConnectionFromName = ConnectionFrom.transform.name;
                }

            }

            //Debug.Log(col.transform.name);
            connected = true;
            //disconnect = false;

        }
    }
    void OnCollisionExit(Collision col)
    {
        if(ConnectionFrom == col.transform.gameObject)
        {
            connected = false;
            ConnectionFrom = null;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if(!connected && col.transform.GetComponent<CircuitPuzzle>().connected)
        {
            ConnectionFrom = col.transform.gameObject;
            ConnectionFromName = ConnectionFrom.transform.name;
            connected = true;
        }
        if (!connected && !col.transform.GetComponent<CircuitPuzzle>().connected)
        {
            ConnectionFrom = null;
            connected = false;
            col.transform.GetComponent<CircuitPuzzle>().ConnectionFrom = null;
        }
    }

}
