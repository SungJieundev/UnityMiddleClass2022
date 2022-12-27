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
            AddCubeToQueue();
        }
    }

    private void AddCubeToQueue(){

        Cube cube = Instantiate(cubePrefab, defaultSpawnPos, Quaternion.identity, transform).GetComponent<Cube>();

        cube.gameObject.SetActive(false);
        cubesQueue.Enqueue(cube);
    }

    public int GenerateRandomNumber(){

        // 2^1 ~ 2^6
        return (int)Mathf.Pow(2, Random.Range(1,6));
    }

    private Color GetColor(int number){

        return cubeColors[(int)(Mathf.Log(number) / Mathf.Log(2)) -1];
    }

    public Cube Spawn(int number, Vector3 pos){

        if(cubesQueue.Count == 0){

            if(autoQueueGrow){

                cubesQueueCapacity++;
                AddCubeToQueue();
            }
            else{

                Debug.Log("Queue is Empty");
                return null;
            }
        }

        Cube cube = cubesQueue.Dequeue();
        cube.transform.position = pos;
        cube.SetNumber(number);
        cube.SetColor(GetColor(number));
        cube.gameObject.SetActive(true);

        return cube;
    }

    public Cube SpawnRandom(){

        return Spawn(GenerateRandomNumber(), defaultSpawnPos);
    }

    public void DestroyCube(Cube cube){

        cube.cubeRigidbody.velocity = Vector3.zero;
        cube.cubeRigidbody.angularVelocity = Vector3.zero;
        cube.transform.rotation = Quaternion.identity;
        cube.gameObject.SetActive(false);

        cubesQueue.Enqueue(cube);
    }
}
