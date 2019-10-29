using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveManager : MonoBehaviour {

    //PlayerData data = SaveSystem.LoadPlayer();
    public bool isEnabled;
    public bool lightSwitch;
    public bool isRadioFinished;
    public bool[] numRadioFinished;
    public bool isSwitchTaken;
    public MenuManager manager;

    private static SaveManager save;

    //bool firstTime = true;

    public string SceneName;
    public int sceneID;
	void Start ()
    {
        //Object.DontDestroyOnLoad(gameObject);
        //File.Delete(Application.persistentDataPath + "/save.dat");
        
        if (!TheSaveManager.Load())
        {
            //manager.NoContinue();
            Debug.Log("FRESH START");
            SaveData.isGasolinePicked = false;
            SaveData.LightSwitch = false;
            for (int i = 0; i < 7; i++)
            {
                Debug.Log(i);
                SaveData.isInvSlotFull[i] = false;
                SaveData.isInvSlotSet[i] = false;
                SaveData.InvSlotTag[i] = "";
                SaveData.InvSlotSprite[i] = "";
            }
            SaveData.isRavenOn = false;
            SaveData.isThroneOn= false;
            SaveData.isCrownOn = false;

            SaveData.isElevOn = false;
            SaveData.isSafeFinished = false;
            SaveData.isInvOn = false;
            SaveData.isTutSeen = false;
            SaveData.isKeyInserted = false;
            SaveData.isBackpackPicked = false;
            SaveData.isRushHourFinished = false;
            SaveData.isPaintingFinished = false;
            SaveData.isGearInserted = false;
            SaveData.isGearsFinished = false;
            SaveData.isCircuitFinished = false;
            SaveData.isSwitch1Inserted = false;
            SaveData.isSwitch2Inserted = false;
            SaveData.isGameFinished = false;
            SaveData.isFuseInserted = false;
            SaveData.isRadioFinished = false;
            SaveData.firstTimeTangram = false;
            SaveData.firstTimeGears = false;
            SaveData.isTangramFinished = false;
            SaveData.isGearPicked = false;
            SaveData.isFusePicked = false;
            TheSaveManager.Save();
        }
        else
        {
            //manager.Continue();
        }
        

    }

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (save == null)
        {
            save = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {

        ////Debug.Log(SaveData.isCubeThere);
        //if (FindObjectsOfType(GetType()).Length > 1)
        //{
        //    Destroy(gameObject);
        //}

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene , LoadSceneMode mode)
    {
        //SaveData.RoomName = scene.name;
        sceneID = scene.buildIndex;
        SceneName = scene.name;
        if(SceneName == "LightHouseGF")
        {

            
            GameObject GameObject1 = GameObject.Find("Cube (2)");
            //Debug.Log(TheSaveManager.Load());
            //Debug.Log(SaveData.isCubeThere);
            StartCoroutine(VVV(GameObject1));



        }
    }

    //public void SaveFunc()
    //{

    //    SaveSystem.SavePlayer(gameObject);
    //}
    IEnumerator VVV(GameObject go)
    {
        yield return 0;
        go.SetActive(SaveData.isGasolinePicked);
    }

}
