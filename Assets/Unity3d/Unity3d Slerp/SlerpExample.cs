using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpExample : MonoBehaviour {

    public Transform sunrise;
    public Transform sunset;

    public float journeyTime = 1.0f;

    private float startTime;

	// Use this for initialization
	void Start ()
    {
        startTime = Time.time;
	}

    //球星插值
    void Slerp()
    {
        Vector3 center = (sunrise.position + sunset.position) * 0.5F;
        center -= new Vector3(0, 1, 0);
        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;
        float fracComplete = (Time.time - startTime) / journeyTime;
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
    }

    //线性插值
    void Lerp()
    {
        transform.position = Vector3.Lerp(new Vector3(0,0,0), new Vector3(10,10,10), 2.0f);
    }
    // Update is called once per frame
    void Update ()
    {
        //Slerp();
        Lerp();
    }
}
