using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomManager : MonoBehaviour {

    public SafePuzzle[] Pieces;

    public GameObject painting1;
    public GameObject painting2;

    public GameObject Cam;
    public GameObject paintingCam;
    public GameObject switch1;

    public GameObject tangram;
    // Use this for initialization
    void Start()
    {
        if(SaveData.isTangramFinished)
        {
            tangram.GetComponent<BoxCollider>().enabled = false;
        }
        if (SaveData.isPaintingFinished)
        {
            painting1.gameObject.SetActive(false);
            painting2.gameObject.SetActive(true);
        }
        else
        {
            painting1.gameObject.SetActive(true);
            painting2.gameObject.SetActive(false);
        }
        if (SaveData.isSafeFinished)
        {
            foreach (SafePuzzle Piece in Pieces)
            {
                Piece.isConnected = true;
            }
        }
        else
        {
            foreach (SafePuzzle Piece in Pieces)
            {
                Piece.isConnected = false;
            }
        }

        if (SaveData.firstTimeTangram)
        {
            Cam.SetActive(false);
            paintingCam.SetActive(true);
            //switch1.SetActive(true);
            //SaveData.firstTimeTangram = false;
            //TheSaveManager.Save();
        }
        else
        {
            Cam.SetActive(true);
            paintingCam.SetActive(false);
            //switch1.SetActive(true);
        }




    }
	
	// Update is called once per frame
	void Update () {
        switch1.SetActive(SaveData.firstTimeTangram);
	}
}
