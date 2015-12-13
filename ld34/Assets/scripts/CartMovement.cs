using UnityEngine;
using System.Collections;

public class CartMovement : MonoBehaviour {

    public BezierPath path;
    /// <summary>
    /// Amount of time the cart will move between 2 points of the bezier curve
    /// </summary>
    public float timeLengh;
    private float timeSinceStart;
    private float e;

    private Quaternion startOrient;
    public Camera theCamera;

	// Use this for initialization
	void Start () {
        timeSinceStart = 0;
        e = 0.2f;

        startOrient = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceStart += Time.deltaTime;
        float tPosition = timeSinceStart / timeLengh;
        //clamp to 1 as max
        // if (tPosition > 1.0) tPosition = 1;

        gameObject.transform.position = path.GetPositionByT(tPosition);

        Vector3 current = path.GetPositionByT(tPosition);
        Vector3 futur = path.GetPositionByT(tPosition + e);

        Vector3 direction = futur - current;
        Vector3 forward = Vector3.forward;

        direction = direction.normalized;

        float angle = Mathf.Acos(Vector3.Dot(forward, direction));
        print("direction vector = " + direction);
        print("Dot : " + Vector3.Dot(forward, direction));
        print("Angle : " + angle + " Degree : " + RadianToDegree(angle));
        //Vector3 rotation = new Vector3(0, 0, RadianToDegree(angle));
        gameObject.transform.rotation = startOrient;

        if (direction.x < 0)
            angle = -angle;

        gameObject.transform.Rotate(new Vector3(0, 0, RadianToDegree(angle)));
        //theCamera.transform.Rotate(new Vector3(0, RadianToDegree(angle), 0));
    }

    private float RadianToDegree(float angle)
    {
        return angle * (180.0f / Mathf.PI);
    }
}
