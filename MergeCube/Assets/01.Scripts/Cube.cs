using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    [SerializeField] private TMP_Text[] numberList;
    public Color cubeColor;
    public int cubeNumber;
    public Rigidbody cubeRigidbody;
    public MeshRenderer meshRenderer;

    private void Awake() {
        
        meshRenderer = GetComponent<MeshRenderer>();
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    public void SetColor(Color color){

        meshRenderer.material.color = color;
    }

    public void SetNumber(int number){

        cubeNumber = number;
        for(int i = 0; i < 6; i++){

            numberList[i].text = number.ToString();
        }
    }
}
