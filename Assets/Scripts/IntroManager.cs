using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

    public AudioClip clip;
    public AudioSource source;
    public interSceneMovement interSceneMovement;

    public Image image;
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    bool skipable =  false;

    public interSceneMovement skip;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Wait());
        skipable = false;
        //StartCoroutine(PlayClip());
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(skipable)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                skip.DoIt();
            }
        }
	}

    IEnumerator PlayClip()
    {
        yield return new WaitForSeconds(1);
        source.clip = clip;
        source.Play();
        yield return new WaitForSeconds(clip.length);
        interSceneMovement.DoIt();

    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(PlayClip());
        yield return new WaitForSeconds(4);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        skipable = true;
        for(int i = 0; i <= 10; i++)
        {
            yield return new WaitForSeconds(0.05f);
            var tempcolor = image.color;
            tempcolor.a += 0.1f;

            image.color = tempcolor;
            textMeshPro1.color = tempcolor;
            textMeshPro2.color = tempcolor;
        }
        yield return null;
    }
}
