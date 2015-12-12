using UnityEngine;
using System.Collections;

public class CartMovement : MonoBehaviour {

    public BezierPath path;
    public float timeLengh;
    private float timeSinceStart;
    private float e;

    private Quaternion startOrient;

	// Use this for initialization
	void Start () {
        timeSinceStart = 0;
        e = 0.1f;

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

        direction.Normalize();

        float angle = Mathf.Acos(Vector3.Dot(forward, direction));
        //print(angle);

        gameObject.transform.rotation = startOrient;
        gameObject.transform.Rotate(new Vector3(0, 0, RadianToDegree(angle)));
    }

    private float RadianToDegree(float angle)
    {
        return angle * (180.0f / Mathf.PI);
    }
}
