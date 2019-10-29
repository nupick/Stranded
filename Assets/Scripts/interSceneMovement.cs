using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class interSceneMovement : MonoBehaviour
{

    public Animator anim;// = GameObject.Find("FadeAnimator").GetComponent<Animator>();
    public Image img;// = GameObject.Find("FadeAnimator").GetComponent<Image>();
    public int scn;                // Use this for initialization
    void Start()
    {
        anim = GameObject.Find("FadeAnimator").GetComponent<Animator>();
        img = GameObject.Find("FadeAnimator").GetComponent<Image>();
        //StartCoroutine(FadingOut());
    }

    void Update()
    {
        //anim = GameObject.Find("FadeAnimator").GetComponent<Animator>();
        //img = GameObject.Find("FadeAnimator").GetComponent<Image>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        //if (SceneManager.GetActiveScene().name == "LightHouseGF")
        //{
        //    if (SaveData.isElevOn)
        //    {
        //        StartCoroutine(FadingIn());
        //    }
        //}
        //else
        //{
        //    StartCoroutine(FadingIn());
        //}
        if(scn != 1)
        {
            SaveData.levelID = scn;
            TheSaveManager.Save();
        }
        else
        {
            SaveData.levelID = SceneManager.GetActiveScene().buildIndex;
            TheSaveManager.Save();
        }

        
        StartCoroutine(FadingIn());
        
    }


    IEnumerator FadingOut()
    {
        anim.SetBool("Fade", false);
        //yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => img.color.a == 1);
        //SceneManager.LoadScene(scn.name);
    }

    IEnumerator FadingIn()
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(scn, LoadSceneMode.Single);
    }

    public void DoIt()
    {
        StartCoroutine(FadingIn());
    }
    public void FadeOut()
    {
        StartCoroutine(FadingOut());
    }

}
