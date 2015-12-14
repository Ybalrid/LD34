using UnityEngine;
using System.Collections;

public class TargetDestroyReact : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.tag = "ShootingTarget";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        ParticleSystem explode = GetComponent<ParticleSystem>();
        //WaitForSeconds wait = new WaitForSeconds(1);
        print("I've been destroyed!");
    }
}
