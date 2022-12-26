using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pushForce;
    [SerializeField] private float cubeMaxPositionX;

    [SerializeField] private TouchSlider touchSlider;
    [SerializeField] private Cube mainCube;
    private Vector3 cubePos;
    private bool isPointerDown;

    private void Start() {

        touchSlider.OnPointerDownEvent += OnPointerDown;
        touchSlider.OnPointerUpEvent += OnPointerUp;
        touchSlider.OnPointerDragEvent += OnPointerDrag;
    }

    private void Update() {
        
        if(isPointerDown){

            mainCube.transform.position = Vector3.Lerp(mainCube.transform.position,
                                                        cubePos,moveSpeed * Time.deltaTime);
        }
    }

    private void OnPointerDown(){

        isPointerDown = true;
    }
    private void OnPointerUp(){

        if(isPointerDown) isPointerDown = false;

        // cube 발사 
        mainCube.cubeRigidbody.AddForce(Vector3.forward * pushForce);
    }
    private void OnPointerDrag(float x){

        if(isPointerDown){

            cubePos = mainCube.transform.position;
            cubePos.x = cubeMaxPositionX * x;
        }
    }

    private void OnDestroy(){

        touchSlider.OnPointerDownEvent -= OnPointerDown;
        touchSlider.OnPointerUpEvent -= OnPointerUp;
        touchSlider.OnPointerDragEvent -= OnPointerDrag;
    }
}
