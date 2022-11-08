using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float _previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];


    public GameObject gameOverPanel;

    private void Update() {

        if(Input.GetKeyDown(KeyCode.LeftArrow)){

            transform.position += new Vector3(-1, 0, 0);

            if(!ValidMove()){

                transform.position -= new Vector3(-1, 0, 0);
            }
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow)){

            transform.position += new Vector3(1, 0, 0);

            if(!ValidMove()){

                transform.position -= new Vector3(1, 0, 0);
            }
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow)){

            //rotate
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);

            if(!ValidMove()){

                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }

        if(Time.time - _previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime)){

            transform.position += new Vector3(0, -1, 0);

            if(!ValidMove()){

                if(fallTime >= 0.75f){

                    GameOver();
                    return;
                }

                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();

                CheckForLines();

                this.enabled = false;
                FindObjectOfType<SpawnTetromino>().NewTetromino();
            }

            _previousTime = Time.time;
        }
    }

    bool ValidMove(){

        foreach (Transform child in transform){

            int roundX = Mathf.RoundToInt(child.transform.position.x);
            int roundY = Mathf.RoundToInt(child.transform.position.y);

            if(roundX < 0 || roundX >= width || roundY < 0 || roundY >= height){

                return false;
            }

            if(grid[roundX, roundY] != null){

                return false;
            }
        }

        return true;
    }

    void AddToGrid(){

        foreach(Transform children in transform){

            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    // 체크라인 -> 한줄의 그리드가 채워졌는지 확인 -> 라인삭제 -> 라인 내려보냄
    void CheckForLines(){

        for(int i = height - 1; i >= 0; i--){

            if(hasLine(i)){

                DeleteLines(i);
                RowDown(i);
            }
        }
    }

    bool hasLine(int i){

        for(int j = 0; j < width; j++){

            if(grid[j, i] == null){

                return false;
            }
        }
        return true;
    }

    void DeleteLines(int i){
        
        for(int j = 0; j < width; j++){

            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
            SpawnTetromino.score++;
        }
    }

    void RowDown(int i){

        for(int y = i; y < height; y++){

            for(int j = 0; j < width; j++){

                if(grid[j, y] != null){

                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void GameOver(){
        gameOverPanel.SetActive(true);
    }
}
