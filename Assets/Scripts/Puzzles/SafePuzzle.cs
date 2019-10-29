using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePuzzle : MonoBehaviour {

    Vector3 curPos;
    public Vector3 setPos;
    public float xFactor;
    public float yFactor;
    public float settingSpeed;
    public SafePuzzle[] connectedPieces;
    public bool isConnected;
    public AudioSource source;
    public AudioClip clip;
	// Use this for initialization
	void Start ()
    {
        curPos = transform.localPosition;
        //isConnected = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isConnected)
        {
            //Debug.Log(transform.localPosition.x);
            
            if (xFactor != 0 && yFactor != 0)
            {
                transform.localPosition = Vector3.MoveTowards(curPos, new Vector3(xFactor, yFactor, transform.localPosition.z), settingSpeed);
            }
            else if(xFactor!=0 && yFactor==0)
            {
                transform.localPosition = Vector3.MoveTowards(curPos, new Vector3(xFactor, transform.localPosition.y, transform.localPosition.z), settingSpeed);
            }
            else if (xFactor==0&&yFactor!=0)
            {
                transform.localPosition = Vector3.MoveTowards(curPos, new Vector3(transform.localPosition.x, yFactor, transform.localPosition.z), settingSpeed);
            }
        }
        else
        {
            transform.localPosition = curPos;
        }
        
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isConnected == false)
            {
                isConnected = true;
                source.clip = clip;
                source.Play();
                foreach (SafePuzzle Piece in connectedPieces)
                {
                    if (Piece.isConnected == false)
                    {
                        Piece.isConnected = true;
                    }
                    else
                    {
                        Piece.isConnected = false;
                    }
                }
            }
        }
    }
}
