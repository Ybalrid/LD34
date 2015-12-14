using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    private float lastShootTime;
    public float cooldownTime;
    public Camera firstPersonCamera;
    public AudioSource shootSound;
    public AudioSource badShoot;
    public int numberClip;
    private int availableShots;
    private string stringToEdit;
    private GUIStyle style;
    static public uint score = 0;
    private string scoreString;

    // Use this for initialization
    void Start () {
        lastShootTime = 0;
        availableShots = numberClip;
        style = new GUIStyle();
        style.fontSize = 30;
        score = 0;
        DontDestroyOnLoad(this);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, Screen.height - 50, 200, 40), stringToEdit, style);
        GUI.Label(new Rect(10, 10, 200, 40), scoreString, style);
    }
	
	// Update is called once per frame
	void Update () {
        scoreString = "Score : " + score;
        stringToEdit = "Rounds : " + availableShots;
        if (availableShots == 0)
            stringToEdit = "LMB to reaload!";
        //Handle the gun
        if (lastShootTime > cooldownTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastShootTime = 0;
                if (availableShots > 0)
                    shoot();
                else
                    badShoot.Play();
            }
        }
        else
        {
            lastShootTime += Time.deltaTime;
        }

        if(Input.GetMouseButton(1))
        {
            availableShots = numberClip;
        }

    }

    void shoot()
    {
        print("Player shoot!!!");
        availableShots--;
        shootSound.Play();
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
                Destroy(hit.collider.gameObject, .5f);
                hit.collider.gameObject.GetComponent<ParticleSystem>().Play();
                score += 10;
            }
            else
            {
                print("This object is NOT a target!");
            }
        }
    }
}
