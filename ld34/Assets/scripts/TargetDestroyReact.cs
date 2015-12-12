using UnityEngine;
using System.Collections;

public class TargetDestroyReact : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        print("I've been destroyed!");
    }
}
