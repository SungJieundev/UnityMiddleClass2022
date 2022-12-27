using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{   
    static int staticId = 0;
    [SerializeField] private TMP_Text[] numberList;

    public int cubeId;
    public Color cubeColor;
    public int cubeNumber;
    public Rigidbody cubeRigidbody;
    public MeshRenderer meshRenderer;

    private void Awake() {
        
        cubeId = staticId++;
        meshRenderer = GetComponent<MeshRenderer>();
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    public void SetColor(Color color){

        cubeColor = color;
        meshRenderer.material.color = color;
    }

    public void SetNumber(int number){

        cubeNumber = number;
        for(int i = 0; i < 6; i++){

            numberList[i].text = number.ToString();
        }
    }
}
