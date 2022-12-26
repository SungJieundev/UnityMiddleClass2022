using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    // Object Pooling

    public static CubeSpawner Instance = null;
    Queue<Cube> cubesQueue = new Queue<Cube>();
 
    [SerializeField] private int cubesQueueCapacity = 20;
    [SerializeField] private bool autoQueueGrow = true;

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Color[] cubeColors;

    public int maxCubeNumber;
    private int maxPower = 12; // 2^12

    private Vector3 defaultSpawnPos;

    private void Awake() {
        
        if(Instance == null) Instance = this;
        else Destroy(gameObject);

        defaultSpawnPos = transform.position;
        maxCubeNumber = (int)Mathf.Pow(2, maxPower);
    }

    private void InitCubeQueue(){

        for(int i = 0; i < cubesQueueCapacity; i++){

            //큐브 생성해서 Queue에 Enqueue
            
        }
    }
}
