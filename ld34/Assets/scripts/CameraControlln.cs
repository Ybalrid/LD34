using UnityEngine;
using System.Collections;

public class CameraControlln : MonoBehaviour {

    public Camera theCamera;
    public float rotationSpeed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float time = Time.deltaTime;
        float rotation = time * rotationSpeed;

        float mouseX, mouseY;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        theCamera.transform.Rotate(-mouseY * rotation, 0, 0, Space.Self);
        theCamera.transform.Rotate(0, mouseX * rotation, 0, Space.World);


    }
}
