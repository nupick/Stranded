using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushHourPuzzle : MonoBehaviour {

    Vector3 currentPos;
    Vector3 nextPos;
    public float speed;
    public float xFactor;
    float XtravelDistance;
    float YtravelDistance;
    public float yFactor;
    bool clickable = true;
    public bool movable = true;
    public string test;

    public AudioSource source;
    public AudioClip clip;
    // Use this for initialization
    void Start ()
    {
        currentPos = transform.parent.localPosition;
        XtravelDistance = xFactor;
        YtravelDistance = yFactor;
    }
	
	// Update is called once per frame
	void Update () {
        nextPos = new Vector3(xFactor * Time.deltaTime, yFactor, 0);
        //Debug.Log("movable: " + movable + " GameObject: " + gameObject.name + " Parent: " + gameObject.transform.parent);
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (clickable)
            {
                if (movable)
                {
                    source.clip = clip;
                    source.Play();
                    switch (gameObject.tag)
                    {
                        case "RushUp":

                            Debug.Log(transform.parent.localPosition.z - nextPos.y);
                            clickable = false;
                            StartCoroutine(MoveUpSmooth(speed, yFactor));


                            break;
                        case "RushDown":
                            clickable = false;
                            Debug.Log(transform.parent.localPosition.z - nextPos.y);
                            StartCoroutine(MoveUpSmooth(speed, -yFactor));
                            //StartCoroutine(MoveDownSmooth());
                            break;
                        case "RushLeft":
                            clickable = false;
                            StartCoroutine(MoveLeftSmooth(speed, -xFactor));
                            break;

                        case "RushRight":
                            clickable = false;
                            StartCoroutine(MoveLeftSmooth(speed, xFactor));
                            break;
                    }
                }
            }
        }
    }
    IEnumerator MoveUpSmooth(float movementSpeed,float slideAmount)
    {
        float movementProgress = 0;
        Vector3 currentPosition = transform.parent.position;
        Vector3 Destination = new Vector3(currentPosition.x,currentPosition.y+slideAmount,currentPosition.z);

        while (movementProgress <= 1)
        {
            movementProgress += movementSpeed * Time.deltaTime;
            transform.parent.position = Vector3.Lerp(currentPosition, Destination, movementProgress);
            yield return 0;
        }
        yield return 0;
        clickable = true;
    }
    IEnumerator MoveLeftSmooth(float movementSpeed, float slideAmount)
    {
        float movementProgress = 0;
        Vector3 currentPosition = transform.parent.position;
        Vector3 Destination = new Vector3(currentPosition.x+slideAmount, currentPosition.y, currentPosition.z);

        while (movementProgress <= 1)
        {
            movementProgress += movementSpeed * Time.deltaTime;
            transform.parent.position = Vector3.Lerp(currentPosition, Destination, movementProgress);
            yield return 0;
        }
        yield return 0;
        clickable = true;
    }
    void OnTriggerStay(Collider col)
    {
        test = col.gameObject.name + "  " +col.isTrigger ;
        if (col.isTrigger == false)
        {
            if (!col.name.Contains("GameObject"))
            {
                movable = false;
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        movable = true;
        col.GetComponent<RushHourPuzzle>().movable = true;

    }
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.collider.isTrigger == false)
    //    {
    //        movable = false;
    //        col.transform.gameObject.GetComponent<RushHourPuzzle>().movable = false;

    //    }
    //    else
    //    {
    //        movable = true;
    //        col.transform.gameObject.GetComponent<RushHourPuzzle>().movable = true;
    //    }
    //}
    //void OnCollisionExit(Collision col)
    //{
    //    movable = true;
    //    col.transform.gameObject.GetComponent<RushHourPuzzle>().movable = true;
    //    Debug.Log(col.transform.gameObject.name);
    //}
}
