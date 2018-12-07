using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithAnimationShake : MonoBehaviour {

    public Animator camAnim;
    public ParticleSystem explodeStar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            camAnim.SetTrigger("Shake");

            explodeStar.Play();
        }  
    }
}
