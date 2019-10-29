using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvas : MonoBehaviour
{
    interSceneMovement scn;
    // Use this for initialization
    void Start()
    {

        GameObject.DontDestroyOnLoad(gameObject);
        //GameObject.DontDestroyOnLoad();
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }


    }
}
