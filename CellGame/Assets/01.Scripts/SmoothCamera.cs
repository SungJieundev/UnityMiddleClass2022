using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{   
    public Transform target;
    public float speed;
    private void Update() {
        
        Vector3 posLerp = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        posLerp.z = transform.position.z;

        transform.position = posLerp;
    }
}
