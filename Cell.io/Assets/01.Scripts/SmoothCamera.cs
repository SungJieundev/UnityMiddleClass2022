using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public float speed;
    public float scaleSpeed;

    public Transform target;
    public Camera cam;

    private void Update(){
        
        Vector3 posLerp = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        posLerp.z = transform.position.z;

        transform.position = posLerp;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3 * target.localScale.x, scaleSpeed * Time.deltaTime);
    }
}
