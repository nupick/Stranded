using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitPuzzleManager : MonoBehaviour {
    public CircuitPuzzle[] lamps;
    //public int num;
    public bool[] dd;
    bool PuzzleFinished;
    int num = 0;
    public GameObject puzzle;
    public interSceneMovement interScene;
    // Use this for initialization
    void Start ()
    {
        lamps = FindObjectsOfType<CircuitPuzzle>();
        //lamps = GameObject.FindGameObjectsWithTag("");
	}
	
	// Update is called once per frame
	void Update ()
    {
        num = 0;
        for (int i = 0; i < lamps.Length; i++)
        {
            if (lamps[i].GetComponent<CircuitPuzzle>().connected)
            {
                if (lamps[i].tag == "Circuit Lamp")
                {
                    num++;
                }
            }
            //else
            //{
            //    num--;
            //}
            //Debug.Log(num);
        }

        //Debug.Log(num);
        if (PuzzleFinished)
        {
            Debug.Log("YAY!");
        }


        if (num >= 13)
        {
            MeshCollider[] colchidren = gameObject.GetComponentsInChildren<MeshCollider>();

            foreach (MeshCollider bc in colchidren)
            {
                bc.enabled = false;
            }
            //if (transform.localPosition.y < 8.40f)
            //{
            //    transform.Translate(Vector3.forward * 0.25f * Time.deltaTime, Space.Self);
            //}
            SaveData.isCircuitFinished = true;
            TheSaveManager.Save();
            interScene.DoIt();
        }
    }

    
    
}
