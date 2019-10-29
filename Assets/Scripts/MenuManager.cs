using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour {
    //public bool INTINT = false;
    public GameObject Setting;// = new GameObject();
    public GameObject Credits;// = new GameObject();
    public interSceneMovement scene;// = new interSceneMovement();
    public Button button;
    public Image image;
    public TextMeshProUGUI text;
    // Use this for initialization
    void Start ()
    {
        //Setting = new GameObject();
        //Credits = new GameObject();
        scene = new interSceneMovement();

        //scene.scn = GameObject.Find(SaveData.RoomName);

        //NoContinue();
        if (TheSaveManager.Load())
        {
            Continue();
        }
        else
        {
            NoContinue();
        }
        
        //Settings();
    }
	
	// Update is called once per frame
	void Update ()
    {
    }
    void Onclick()
    {

    }
    public void Activation()
    {
        Credits.SetActive(false);
        if (Setting.activeSelf == true)
        {
            Setting.SetActive(false);
        }
        else
        {
            Setting.SetActive(true);
        }
    }

    public void CreditsActivation()
    {
        Setting.SetActive(false);
        if(Credits.activeSelf == true)
        {
            Credits.SetActive(false);
        }
        else
        {
            Credits.SetActive(true);
        }
    }


    public void StartNewGame()
    {

    }
    public void NoContinue()
    {
        button.enabled = false;
        image.enabled = false;
        text.color = new Color(1, 1, 1, 0.2313726f);
    }
    public void Continue()
    {
        button.enabled = true;
        image.enabled = true;
        text.color = new Color(1, 1, 1, 1);
    }
}
