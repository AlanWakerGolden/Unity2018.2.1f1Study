using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orginalPosition = transform.position;
        float elapse = 0f;
        while (elapse < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;
            transform.position = new Vector3(x,y,0);
            elapse += Time.deltaTime;
            yield return 0;
        }
        transform.position = orginalPosition;
    }	
}
