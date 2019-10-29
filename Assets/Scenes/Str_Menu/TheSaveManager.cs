using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TheSaveManager
{
    void Sart()
    {
        
    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
        SerializableSaveData serializableSaveData = new SerializableSaveData();
        bf.Serialize(file, serializableSaveData);
        file.Close();
        //Debug.Log (SaveData.currentLevel);
    }

    public static bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            SerializableSaveData serializableSaveData = (SerializableSaveData)bf.Deserialize(file);
            file.Close();
            serializableSaveData.RestoreSaveData();
            //Debug.Log(SaveData.isCubeThere);
            return (true);
        }
        else
        {
            return (false);
        }
    }
}

public class SaveData
{
    public static bool isGasolinePicked;
    public static bool isKeyPicked;
    public static bool isSwitch1Picked;
    public static bool isSwitch2Picked;
    public static bool isFusePicked;
    public static bool isGearPicked;
    public static bool isBackpackPicked;



    public static bool isElevOn;

    public static bool isThroneOn;
    public static bool isCrownOn;
    public static bool isRavenOn;


    public static bool isInvOn;

    public static bool LightSwitch;
    public static bool[] isInvSlotFull = new bool[7];
    public static bool[] isInvSlotSet = new bool[7];
    public static string[] InvSlotSprite = new string[7];
    public static string[] InvSlotTag = new string[7];


    public static bool isSafeFinished;

    public static bool isTutSeen;

    public static bool isKeyInserted;

    public static bool isRushHourFinished;

    public static bool isPaintingFinished;

    public static bool isGearInserted;
    public static bool isGearsFinished;
    public static bool firstTimeGears;

    public static bool isCircuitFinished;

    public static bool isSwitch1Inserted;
    public static bool isSwitch2Inserted;

    public static bool isGameFinished;

    public static bool isTangramFinished;
    public static bool firstTimeTangram;

    public static int levelID;

    public static bool isFuseInserted;

    public static bool isRadioFinished;
}

[Serializable]
public class SerializableSaveData
{
    //inventory item save
    private bool isGasolinePicked = SaveData.isGasolinePicked;
    private bool isKeyPicked = SaveData.isKeyPicked;
    private bool isSwitch1Picked = SaveData.isSwitch1Picked;
    private bool isSwitch2Picked = SaveData.isSwitch2Picked;
    private bool isFusePicked = SaveData.isFusePicked;
    private bool isGearPicked = SaveData.isGearPicked;
    private bool isBackpackPicked = SaveData.isBackpackPicked;

    //Elevator Save
    private bool isElevOn = SaveData.isElevOn;


    //light switch save
    private bool LightSwitch = SaveData.LightSwitch;

    //Tutorial Panel
    private bool isTutSeen = SaveData.isTutSeen;


    //Inventory Save
    private bool[] isInvSlotFull = SaveData.isInvSlotFull;
    private bool[] isInvSlotSet = SaveData.isInvSlotSet;
    private string[] InvSlotSprite = SaveData.InvSlotSprite;
    private string[] InvSlotTag = SaveData.InvSlotTag;
    private bool isInvOn = SaveData.isInvOn;


    //Safe Puzzle
    private bool isSafeFinished = SaveData.isSafeFinished;

    //Radio Puzzle
    private bool isThroneOn = SaveData.isThroneOn;
    private bool isCrownOn = SaveData.isCrownOn;
    private bool isRavenOn = SaveData.isRavenOn;
    private bool isRadioFinished = SaveData.isRadioFinished;

    //Warehouse Wardrobe
    private bool isKeyInserted = SaveData.isKeyInserted;

    //Rush Hour Puzzle
    private bool isRushHourFinished = SaveData.isRushHourFinished;

    //Painting Puzzle
    private bool isPaintingFinished = SaveData.isPaintingFinished;

    //Gears Puzzle
    private bool isGearInserted = SaveData.isGearInserted;
    private bool isGearsFinished = SaveData.isGearsFinished;
    private bool firstTimeGears = SaveData.firstTimeGears;


    //Circuit Puzzle
    private bool isCircuitFinished = SaveData.isCircuitFinished;

    //Tangram Puzzle
    private bool isTangramFinished = SaveData.isTangramFinished;
    private bool firstTimeTangram = SaveData.firstTimeTangram;

    //Final Puzzle
    private bool isSwitch1Inserted = SaveData.isSwitch1Inserted;
    private bool isSwitch2Inserted = SaveData.isSwitch2Inserted;

    //levelID

    private int levelID = SaveData.levelID;

    private bool isFuseInserted = SaveData.isFuseInserted;

    private bool isGameFinished = SaveData.isGameFinished;

    public void RestoreSaveData()
    {
        
        SaveData.isGasolinePicked = isGasolinePicked;
        SaveData.isKeyPicked = isKeyPicked;
        SaveData.isSwitch1Picked = isSwitch1Picked;
        SaveData.isSwitch2Picked = isSwitch2Picked;
        SaveData.isFusePicked = isFusePicked;
        SaveData.isGearPicked = isGearPicked;
        SaveData.isBackpackPicked = isBackpackPicked;

        SaveData.isElevOn = isElevOn;

        SaveData.isInvOn = isInvOn;

        SaveData.LightSwitch = LightSwitch;

        SaveData.isPaintingFinished = isPaintingFinished;


        SaveData.isThroneOn = isThroneOn;
        SaveData.isCrownOn = isCrownOn;
        SaveData.isRavenOn = isRavenOn;


        SaveData.isInvSlotFull = isInvSlotFull;
        SaveData.isInvSlotSet = isInvSlotSet;
        SaveData.InvSlotSprite = InvSlotSprite;
        SaveData.InvSlotTag = InvSlotTag;

        SaveData.isSafeFinished = isSafeFinished;

        SaveData.isTutSeen = isTutSeen;

        SaveData.isKeyInserted = isKeyInserted;

        SaveData.isRushHourFinished = isRushHourFinished;

        SaveData.isGearInserted = isGearInserted;
        SaveData.isGearsFinished = isGearsFinished;

        SaveData.isCircuitFinished = isCircuitFinished;

        SaveData.isSwitch1Inserted = isSwitch1Inserted;
        SaveData.isSwitch2Inserted = isSwitch2Inserted;

        SaveData.firstTimeGears = firstTimeGears;
        SaveData.firstTimeTangram = firstTimeTangram;
        SaveData.isTangramFinished = isTangramFinished;

        SaveData.levelID = levelID;

        SaveData.isFuseInserted = isFuseInserted;

        SaveData.isRadioFinished = isRadioFinished;

        SaveData.isGameFinished = isGameFinished;
    }
}

