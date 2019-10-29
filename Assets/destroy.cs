using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroy : MonoBehaviour {

    private static destroy dst;
    int a = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(this.gameObject);
            
        }


    }
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (dst == null)
        {
            dst = this;
        }
        else
        {
            Destroy(gameObject);
        }


        
    }
}
