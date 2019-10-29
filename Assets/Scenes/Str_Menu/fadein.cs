using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein : MonoBehaviour {

    public float speed = 0.2f;
    public void FadeMe()
    {
        StartCoroutine(FadeIN());
    }


    IEnumerator FadeIN()
    {
        CanvasGroup CV = GetComponent <CanvasGroup>();
        while (CV.alpha != 1)
        {
            CV.alpha += speed * Time.deltaTime;
            //Debug.Log("Trying");
        }
        yield return null;
        Debug.Log("There");
    }
}
