using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeStar : MonoBehaviour
{
    public ParticleSystem explodePartical;
    public CameraShake cameraShake;

	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            explodePartical.Play();
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        }
    }
}
