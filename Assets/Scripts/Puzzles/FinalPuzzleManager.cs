using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleManager : MonoBehaviour {
    public FinalPuzzle[] buttons;
    public string buttonName;
    public bool connected=false;
    public int counter = 0;
    public interSceneMovement inter ;

    int n = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(connected)
        {
            if(buttons[counter].name==buttonName)
            {
                counter++;
                connected = false;
            }
            else
            {
                counter = 0;
                Debug.Log("Test");
                foreach(FinalPuzzle button in buttons)
                {
                    if(button.set)
                    {
                        button.button.transform.Translate(new Vector3(0, 0.02f, 0), Space.World);
                        foreach (BoxCollider bc in button.GetComponents<BoxCollider>())
                        {
                            bc.enabled = true;
                        }
                    }
                    button.set = false;
                    
                }
                connected = false;
            }

        }
        if(counter == 6)
        {
            n++;
            if(n==1)
            {
                StartCoroutine(FinishGame());
            }
        }


	}

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(0.5f);
        SaveData.isGameFinished = true;
        TheSaveManager.Save();
        inter.DoIt();
    }
}
