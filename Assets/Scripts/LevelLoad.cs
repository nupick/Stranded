using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour {


    public Animator anim;
    public Image img;
    // Use this for initialization
    void Awake ()
    {
        anim = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
        img = GameObject.FindGameObjectWithTag("Fade").GetComponent<Image>();
        StartCoroutine(FadingOut());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FadingOut()
    {
        anim.SetBool("Fade", false);
        //yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => img.color.a == 1);
        //SceneManager.LoadScene(scn.name);
    }
}
