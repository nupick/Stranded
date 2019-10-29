using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    //The Ground Floor
    public bool isEnabled;
    public bool lightSwitch;
    public bool isRadioFinished;
    public bool[] numRadioFinished;
    public bool isSwitchTaken;



    /// <summary>
    /// the
    /// </summary>
    public PlayerData(GameObject manager)
    {
        isEnabled = manager.activeSelf;
        //lightSwitch = manager.lightSwitch;

    }
    //public PlayerData(GameObject nn,int a)
    //{

    //}
}
