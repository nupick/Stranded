using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackInteraction : MonoBehaviour {


    public GameObject backpack;
    public GameObject inventory;
    public AudioSource source;
    public AudioClip clip;
    public Sprite sprite;
    public string Tag;
    public ObjectPickUp pick;


    // Use this for initialization
    void Start () {
        //pick = new ObjectPickUp();
        Tag = "Flashlight";
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(clip.length);
        gameObject.SetActive(!SaveData.isBackpackPicked);
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            StartCoroutine(PlaySound());
            //pick.PickUp(sprite, Tag);
            SaveData.isBackpackPicked = true;
            SaveData.isInvOn = true;
            inventory.SetActive(true);
            //SaveData.isInvOn = true;
            ////source.clip = clip;
            ////source.Play();
            //TheSaveManager.Save();
            //backpack.SetActive(false);
            //inventory.SetActive(true);

        }
    }
    void OnMouseDown()
    {
        //StartCoroutine(PlaySoune());
    }

    IEnumerator PlaySound()
    {

        DontDestroyOnLoad(this.gameObject);
        source.clip = clip;
        source.Play();
        backpack.GetComponent<MeshRenderer>().enabled = false;
        backpack.GetComponent<BoxCollider>().enabled = false;
        inventory.SetActive(true);

        yield return new WaitForSeconds(clip.length);
        TheSaveManager.Save();

        Destroy(gameObject);
    }


}
