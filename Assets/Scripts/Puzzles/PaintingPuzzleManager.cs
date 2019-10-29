using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaintingPuzzleManager : MonoBehaviour {
    public PaintingPuzzle[] paintings;
    public bool[] dd;
    bool PuzzleFinished;
    public int num = 0;
    public GameObject puzzle;
    public AudioSource source;
    public AudioClip clip;

    public float time;
    int i = 0;
    // Use this for initialization
    void Start ()
    {
        foreach (PaintingPuzzle go in paintings)
        {
            //go.GetComponent<BoxCollider>().enabled = false;
            //go.GetComponent<BoxCollider>().enabled = true;
            //foreach (GameObject ggo in FindObjectsOfType<>())
            //{

            //}
        }

    }
    
    // Update is called once per frame
    void Update () {
        num = 0;
        for (int i = 0; i < 15; i++)
        {
            if(paintings[i].rightPlace)
            {
                num++;
            }
            //else
            //{
            //    num--;
            //}
        }

        Debug.Log(SaveData.isPaintingFinished);
        
        //Debug.Log(num);
        if (PuzzleFinished)
        {
            Debug.Log("YAY!");
        }
        

        if(num >= 14)
        {
            SaveData.isPaintingFinished = true;
            TheSaveManager.Save();
            BoxCollider[] colchidren = gameObject.GetComponentsInChildren<BoxCollider>();

            foreach(BoxCollider bc in colchidren)
            {
                bc.enabled = false;
            }
            if (transform.localPosition.y < 8.40f)
            {
                transform.Translate(Vector3.forward*0.25f*Time.deltaTime, Space.Self);
            }
            else
            {
            }

            puzzle.GetComponent<BoxCollider>().enabled = true;
            i += 1;
            if(i == 1)
            {
                SaveData.isPaintingFinished = true;
                TheSaveManager.Save();
                StartCoroutine(PlaySound());
            }
        }
        else
        {
            puzzle.GetComponent<BoxCollider>().enabled = false;
        }

    }

    IEnumerator PlaySound()
    {
        source.clip = clip;
        source.Play();
        SaveData.isPaintingFinished = true;
        TheSaveManager.Save();
        yield return new WaitForSeconds(time);
        
    }

}
