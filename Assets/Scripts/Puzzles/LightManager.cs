using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public static LightManager lightManager { get; private set; }
    public FuseLight[] fuselightarray = new FuseLight[17];
    public interSceneMovement interScene;

    //public FuseSlot[] Slots = new FuseSlot[72];
    //[System.Serializable]
    //public struct rowData
    //{
    //    public FuseSlot[] fuses;
    //}

    //public rowData[] rows = new rowData[8];
    public FuseSlot[,] SlotsRows = new FuseSlot[8,9];
    



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        int num = 0;
        for (int i = 0; i < 17; i++)
        {
            if (fuselightarray[i].isOn)
            {
                num++;
            }

        }

        if(num>= 17)
        {
            SaveData.isElevOn = true;
            TheSaveManager.Save();
            interScene.DoIt();
        }
    }

    private void Awake()
    {
        lightManager = this;
    }
}
