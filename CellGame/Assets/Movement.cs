using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(input);
        
        transform.position = Vector3.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);
    }
}
