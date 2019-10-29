using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushHourPuzzleManager : MonoBehaviour {
    public GameObject[] current;
    public GameObject[] next;
    public GameObject[] Pieces;
    public GameObject collider;

    public AudioSource source;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.name.Contains("Finish"))
        {
            Debug.Log("TEST");
            foreach (GameObject go in Pieces)
            {
                foreach(BoxCollider bc in go.GetComponentsInChildren<BoxCollider>())
                {
                    bc.enabled = false;
                }
            }
            collider.SetActive(false);
            StartCoroutine(FinishRushHour());
        }
    }

    IEnumerator FinishRushHour()
    {
        yield return new WaitForSeconds(0.1f);
        source.clip = clip;
        source.Play();
        yield return new WaitForSeconds(1f);
        foreach (GameObject go in current)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in next)
        {
            go.SetActive(true);
        }
        SaveData.isRushHourFinished = true;
        TheSaveManager.Save();
    }
}
