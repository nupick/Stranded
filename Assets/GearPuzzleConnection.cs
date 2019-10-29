using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPuzzleConnection : MonoBehaviour {

    public bool isConnected;
    public string oddOrEven;

    public float rotationSpeed;
    public bool rotate;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameObject.tag == "Gears Connection")
        {
            isConnected = true;
            oddOrEven = "Odd";
        }
        if (oddOrEven == "Odd")
        {
            if (rotate)
            {
                transform.Rotate(0, 0, rotationSpeed, Space.Self);
            }
        }
        else if (oddOrEven == "Even")
        {
            if (rotate)
            {
                transform.Rotate(0, 0, -rotationSpeed, Space.Self);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<GearPuzzleConnection>().isConnected)
        {
            if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
            {
                isConnected = true;
            }
            if(col.gameObject.GetComponent<GearPuzzleConnection>().oddOrEven == "Odd")
            {
                if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
                    oddOrEven = "Even";
            }
            else
            {
                if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
                    oddOrEven = "Odd";
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<GearPuzzleConnection>().isConnected)
        {
            if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
            {
                isConnected = true;
            }
            if (col.gameObject.GetComponent<GearPuzzleConnection>().oddOrEven == "Odd")
            {
                if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
                    oddOrEven = "Even";
            }
            else
            {
                if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
                    oddOrEven = "Odd";
            }
        }

    }
    void OnCollisionStay(Collision col)
    {
            if (col.gameObject.GetComponent<GearPuzzleConnection>().isConnected)
            {
            if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
            {
                isConnected = true;
            }
            if (col.gameObject.GetComponent<GearPuzzleConnection>().oddOrEven == "Odd")
            {
                if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
                    oddOrEven = "Even";
            }
            else
            {
                if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
                    oddOrEven = "Odd";
            }
        }
    }
    void OnCollisionExit(Collision col)
    {
        if(isConnected)
        {

            isConnected = false;
            oddOrEven = null;
        }
            
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.GetComponent<GearPuzzleConnection>().isConnected)
        {
            if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
            {
                isConnected = true;
            }
            if (col.gameObject.GetComponent<GearPuzzleConnection>().oddOrEven == "Odd")
            {
                if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
                    oddOrEven = "Even";
            }
            else
            {
                if (!gameObject.GetComponent<GearPuzzleTest>().isPicked)
                    oddOrEven = "Odd";
            }
        }


    }

}
