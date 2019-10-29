using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islandManager : MonoBehaviour {
    public GameObject[] rotatingLight;
    public GameObject[] everythingElse;
    public interSceneMovement inter;

    public AudioSource source;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
        if(SaveData.isGameFinished)
        {
            foreach(GameObject go in rotatingLight)
            {
                go.SetActive(true);
            }
            foreach(GameObject go in everythingElse)
            {
                go.SetActive(false);
            }
            StartCoroutine(InitialWait());
            StartCoroutine(FinishTheGame());
        }
        else
        {
            foreach (GameObject go in rotatingLight)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in everythingElse)
            {
                go.SetActive(true);
            }
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator InitialWait()
    {
        yield return new WaitForSeconds(3);
    }
    IEnumerator FinishTheGame()
    {
        yield return new WaitForSeconds(1);
        source.clip = clip;
        source.Play();
        yield return new WaitForSeconds(8);
        inter.DoIt();
    }
}
