using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsPuzzleManager : MonoBehaviour {
    public GearsPuzzle[] gears;
    public interSceneMovement interScene;
	// Use this for initialization
	void Start ()
    {
        //StartCoroutine(Finished());

    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    void OnCollisionStay(Collision col)
    {
        //Debug.Log(col.transform.name);
        if(col.transform.GetComponent<GearsPuzzle>() != null)
        {
            if(col.transform.GetComponent<GearsPuzzle>().Connected)
            {
                //foreach(GearsPuzzle gear )
                //Debug.Log("Finished");
                transform.Rotate(0, 0, col.transform.GetComponent<GearsPuzzle>().RotationSpeed * -1, Space.Self);

                foreach (GearsPuzzle gear in gears)
                {
                    gear.finished = true;
                }
                Invoke("Finished", 2f);
            }
        }
    }

    void Finished()
    {

        //yield return new WaitForSeconds(2f);
        //new interSceneMovement();
        interScene.DoIt();


    }
}
