using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSoundManager : MonoBehaviour {
    public AudioClip clip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
    {
        StartCoroutine(PlaySoune());
    }
    void Awake()
    {
        
    }
    IEnumerator PlaySoune()
    {
        DontDestroyOnLoad(this.gameObject);
        gameObject.GetComponent<AudioSource>().clip = clip;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(clip.length);
        Destroy(gameObject);
    }
}
