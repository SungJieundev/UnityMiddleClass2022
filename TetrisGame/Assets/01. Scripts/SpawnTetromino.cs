using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnTetromino : MonoBehaviour
{
    public GameObject[] tetrominoes;

    public static int score;
    public Text scoreText;

    public GameObject gameOverPanel;

    public Vector3[] spawnPositions;
    public Queue<GameObject> nextTetrominoes = new Queue<GameObject>();

    void Start()
    {
        for(int i = 0; i < spawnPositions.Length; i++){

            GenerateNext(i);
        }
        NewTetromino();
    }

    void Update(){

        if(scoreText) scoreText.text = score.ToString();
    }

    public void NewTetromino(){

        //Instantiate(tetrominoes[Random.Range(0, tetrominoes.Length)], transform.position, Quaternion.identity);
        GameObject t = nextTetrominoes.Dequeue();
        t.transform.position = transform.position;
        t.GetComponent<TetrisBlock>().enabled = true;

        GenerateNext(spawnPositions.Length - 1);

        MoveSpawnPosition();
    }

    public void GenerateNext(int i){

        GameObject t = Instantiate(tetrominoes[Random.Range(0,tetrominoes.Length)], spawnPositions[i], Quaternion.identity);
        t.GetComponent<TetrisBlock>().gameOverPanel = gameOverPanel;
        t.GetComponent<TetrisBlock>().enabled = false;
        nextTetrominoes.Enqueue(t);
        
    }

    public void MoveSpawnPosition(){

        for(int i = 0; i < spawnPositions.Length; i++){

            GameObject t = nextTetrominoes.Dequeue();
            t.transform.position = spawnPositions[i];
            nextTetrominoes.Enqueue(t);
        }
    }

    public void ReStart(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
