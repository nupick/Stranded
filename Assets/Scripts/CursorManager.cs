using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    //Cursor Textures
    public Texture2D defaultcursortex;
    public Texture2D CursorGoRight;
    public Texture2D Pickable;
    public Texture2D CursorGoLeft;
    public Texture2D CursorGoBack;
    public Texture2D CursorGoForward;
    public Texture2D Puzzle;
    public Texture2D Rotatable;
    public Texture2D RushLeft;
    public Texture2D RushRight;
    public Texture2D RushUp;
    public Texture2D RushDown;


    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursormode;

    //Rays
    Ray ray;
    RaycastHit raycast;
    public Camera cam;


    //string Tag = "";
    string Tag;
    // Use this for initialization
    void Start ()
    {
        cursormode = CursorMode.Auto;
        Cursor.SetCursor(defaultcursortex, hotspot, cursormode);
        foreach(Camera camera in FindObjectsOfType<Camera>())
        {
            if(camera.gameObject.activeSelf == true)
            {
                cam = camera;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(Tag);
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycast))
        {
            Tag = raycast.collider.tag;
            //Debug.Log(Tag);

            Debug.Log(Tag);

            if (Tag == "RightLocation")
            {
                Cursor.SetCursor(CursorGoRight, hotspot, cursormode);
            }
            else if (Tag == "ForwardLocation")
            {
                Cursor.SetCursor(CursorGoForward, hotspot, cursormode);
            }
            else if (Tag == "LeftLocation")
            {
                Cursor.SetCursor(CursorGoLeft, hotspot, cursormode);
            }
            else if (Tag == "BackLocation")
            {
                Cursor.SetCursor(CursorGoBack, hotspot, cursormode);
            }
            else if (Tag == "Pickable" || Tag == "Gears" || Tag == "Painting" || Tag == "Tangram")
            {
                Cursor.SetCursor(Pickable, hotspot, cursormode);
            }
            else if (Tag == "Puzzle")
            {
                Cursor.SetCursor(Puzzle, hotspot, cursormode);
            }
            else if (Tag == "Rotatable")
            {
                Cursor.SetCursor(Rotatable, hotspot, cursormode);
            }
            else if(Tag == "RushLeft")
            {
                Cursor.SetCursor(RushLeft, hotspot, cursormode);

            }
            else if (Tag == "RushRight")
            {
                Cursor.SetCursor(RushRight, hotspot, cursormode);

            }
            else if (Tag == "RushUp")
            {
                Cursor.SetCursor(RushUp, hotspot, cursormode);

            }
            else if (Tag == "RushDown")
            {
                Cursor.SetCursor(RushDown, hotspot, cursormode);

            }
            else
            {
                Cursor.SetCursor(defaultcursortex, hotspot, cursormode);
            }



        }
        else
        {
            Cursor.SetCursor(defaultcursortex, hotspot, cursormode);
        }
    }

    
}
