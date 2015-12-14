using UnityEngine;
using System.Collections;

public class EndTitle : MonoBehaviour {
    int x, y;
    GUIStyle style;

	// Use this for initialization
	void Start () {
        style = new GUIStyle();
        style.fontSize = 50;
        x = 500;
        y = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.Label(new Rect((Screen.width / 2) - (x / 2), (Screen.height / 2) - (y / 2), x, y), "Score : " + PlayerShoot.score + "\nthanks for playing my little game! :-)\n\n\tYbalrid",style);
    }
}
