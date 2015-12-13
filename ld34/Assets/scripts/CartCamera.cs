using UnityEngine;
using System.Collections;

public class CartCamera : MonoBehaviour {

    public Vector3 cameraOffset;
    public Vector3 gunOffset;
    public Vector3 lightOffset;
    public Camera theCamera;
    public Light sidelight;
    public GameObject theGun;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        theCamera.transform.position = position + cameraOffset;
        //theCamera.transform.rotation = gameObject.transform.rotation;
        theGun.transform.rotation = theCamera.transform.rotation;
        theGun.transform.position = theCamera.transform.position + theCamera.transform.rotation * gunOffset;
        sidelight.transform.position = position + gameObject.transform.rotation * lightOffset;
    }
}
