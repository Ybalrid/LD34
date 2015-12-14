using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {

    public BezierPath path;
    public GameObject prefab;
    public float maxTpos;
    public float increment;

	// Use this for initialization
	void Start () {
        
        for(float i = 0; i < maxTpos; i+= increment + Random.Range(0, 1.5f*increment))
        {
            Vector3 pos = path.GetPositionByT(i);
            Vector3 futurePos = path.GetPositionByT(i + 0.01f);
            Vector3 direction = futurePos - pos;
            direction.Normalize();
       
            float dot = Vector3.Dot(Vector3.forward, direction);
            float angle = Mathf.Acos(dot);
            if (direction.x < 0) angle = -angle;
            angle *= Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
            Instantiate(prefab, pos + new Vector3(Random.Range(-2, 1), Random.Range(-1, 2), 0), rotation);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
