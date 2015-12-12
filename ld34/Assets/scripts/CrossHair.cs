using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {

    Rect position;
    public Texture2D crosshairTexture;
    public bool cursorHide;

	// Use this for initialization
	void Start ()
    {
        position = new Rect((Screen.width - crosshairTexture.width) / 2, 
            (Screen.height - crosshairTexture.height) / 2, 
            crosshairTexture.width, 
            crosshairTexture.height);

        Cursor.visible = cursorHide;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Cursor.visible = cursorHide; 
    }

    void OnGUI()
    {
        GUI.DrawTexture(position, crosshairTexture);
    }
}
