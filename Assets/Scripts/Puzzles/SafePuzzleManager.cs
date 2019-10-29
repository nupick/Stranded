using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePuzzleManager : MonoBehaviour {
    public GameObject safeDoor;
    public SafePuzzle[] LockPieces;
    int num;
    public float rotationSpeed = 1;
    // Use this for initialization
    void Start () {
        num = 0;
        if (SaveData.isSafeFinished)
        {
            foreach (SafePuzzle piece in LockPieces)
            {
                piece.isConnected = true;
                Debug.Log("TEST");
            }
        }
    }
	void Awake()
    {
        LockPieces = FindObjectsOfType<SafePuzzle>();
    }
    // Update is called once per frame
    void Update ()
    {
        num = 0;
        for (int i = 0; i < LockPieces.Length; i++)
        {
            if (LockPieces[i].GetComponent<SafePuzzle>().isConnected)
            {
                    num++;
            }
            //else
            //{
            //    num--;
            //}
            //Debug.Log(num);
        }
        if (num >= 7)
        {

            SaveData.isSafeFinished = true;
            TheSaveManager.Save();
            if (safeDoor.transform.localRotation.eulerAngles.y < 70)
            {
                safeDoor.transform.Rotate(0, rotationSpeed* Time.deltaTime, 0);

            }
            //Debug.Log(safeDoor.transform.localRotation.y);
            
        }

        

    }

    //IEnumerator Finish
}
