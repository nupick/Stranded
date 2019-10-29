using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsPuzzleManagerTest : MonoBehaviour {
    public interSceneMovement inter;
    public GameObject[] Gears;
    int n = 0;

    public AudioSource source;
    public AudioClip clip;

    public string pickedGear;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<GearPuzzleConnection>().isConnected)
        {
            foreach (GameObject go in Gears)
            {
                go.GetComponent<GearPuzzleConnection>().rotate = true;
                n++;
                if (n == 1)
                {
                    StartCoroutine(Finished());
                }
            }
        }
		
	}

    IEnumerator Finished()
    {
        source.clip = clip;
        source.Play();
        yield return new WaitForSeconds(1);
        SaveData.isGearsFinished = true;
        SaveData.firstTimeGears = true;
        TheSaveManager.Save();
        inter.DoIt();
    }
}
