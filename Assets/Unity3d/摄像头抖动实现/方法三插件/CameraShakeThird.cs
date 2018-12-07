using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShakeThird : MonoBehaviour {
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {          
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.15f, 1f);
        }
    }
}

