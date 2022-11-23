using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    private float currentScale = 1f;
    public float scaleSpeed = 5f;

    private void OnTriggerEnter2D(Collider2D other) {
        
        currentScale += 1f;
        Destroy(other.gameObject);
        
    }

    private void Update() {
        
        //transform.localScale = new Vector3(currentScale, currentScale, 1);
        transform.localScale = Vector3.Lerp(transform.localScale, 
        new Vector3(currentScale, currentScale, 1),
        Time.deltaTime * scaleSpeed);
    }
}
