using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TangramPuzzleManager : MonoBehaviour
{
    public TangramPuzzle[] tangrams;
    public bool[] dd;
    bool PuzzleFinished;
    int num = 0;
    public GameObject puzzle;
    public interSceneMovement interScene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        num = 0;
        for (int i = 0; i < 8; i++)
        {
            if (tangrams[i].rightPlace)
            {
                num++;
            }
                    
        }

        Debug.Log(num);
        if (PuzzleFinished)
        {
            //Debug.Log("YAY!");
        }


        if (num >= 8)
        {
            SaveData.isTangramFinished = true;
            SaveData.firstTimeTangram = true;
            TheSaveManager.Save();
            interScene.DoIt();
            
        }

    }
}
