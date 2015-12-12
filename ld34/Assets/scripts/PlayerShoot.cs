using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    private float lastShootTime;
    public float cooldownTime;
    public Camera firstPersonCamera;

	// Use this for initialization
	void Start () {
        lastShootTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //Handle the gun
        if (lastShootTime > cooldownTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastShootTime = 0;
                shoot();
            }
        }
        else
        {
            lastShootTime += Time.deltaTime;
        }
	
	}

    void shoot()
    {
        print("Player shoot!!!");
        Vector3 cameraPosition, cameraOrientation;
        cameraPosition = firstPersonCamera.transform.position;
        cameraOrientation = firstPersonCamera.transform.rotation * Vector3.forward;

        Ray aim = new Ray(cameraPosition, cameraOrientation);
        RaycastHit hit;
        if(Physics.Raycast(aim, out hit))
        {
            print("some colider has been shot!");
            if(hit.collider.gameObject.tag == "ShootingTarget")
            {
                print("This object is a target!");
                Destroy(hit.collider.gameObject);
            }
            else
            {
                print("This object is NOT a target!");
            }
        }
    }
}
