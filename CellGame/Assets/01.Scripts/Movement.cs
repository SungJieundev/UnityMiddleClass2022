using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    public Camera cam;
    public float speed;
    public Text NICK;
    //public pH
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(input);

        Vector3 nPos = Vector3.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);

        nPos.z = transform.position.z;
        transform.position = nPos;
    }
}
