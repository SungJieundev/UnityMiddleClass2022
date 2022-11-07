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

                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();

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
}
