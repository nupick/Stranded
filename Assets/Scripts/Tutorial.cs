using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //gameObject.SetActive(!SaveData.isTutSeen);	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.SetActive(!SaveData.isTutSeen);
    }

    public void DestroyTutPanel(GameObject TutPanel)
    {
        SaveData.isTutSeen = true;
        TheSaveManager.Save();
        Destroy(TutPanel);

    }
}
