using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SizeManager : MonoBehaviour
{
    private float currentScale = 1f;
    public float scaleSpeed = 5f;

    int score;

    public GameObject scoreBoard;
    public PhotonView pv;
    public GameObject cell;
    public float sizeIncrease;
    


    private void Start(){

        scoreBoard = GameObject.Find("ScoreBoard");
        scoreBoard.GetComponent<Text>().text = 0.ToString();
    }

    private void Update(){

        transform.localScale = Vector3.Lerp(transform.localScale, 
        new Vector3(currentScale, currentScale, 1), 
        Time.deltaTime * scaleSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "Food"){
            
            currentScale *= 1.05f;
            score += 10;

            if(pv.IsMine){

                scoreBoard.GetComponent<Text>().text = score.ToString();
            }

            GameManager.instance.SpawnFood();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Virus"){
            
            Vector3 mass = transform.localScale;
            if (mass.x < 2f) return;

            transform.localScale = new Vector3(mass.x / 2, mass.y / 2, mass.x / 2);

            GameObject g = Instantiate(cell, transform.parent);
            g.transform.position = new Vector3(transform.position.x + mass.x / 2, transform.position.y + mass.y / 2, 0);

            Destroy(other.gameObject);
            GameManager.instance.SpawnVirus();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Player"){

            if(transform.localScale.x < other.gameObject.transform.localScale.x){
                
                transform.gameObject.SetActive(false);
                pv.RPC("DestroyObjectRPC", RpcTarget.All);
            }

            else if(transform.localScale.x > other.gameObject.transform.localScale.x){

                other.gameObject.SetActive(false);
            }

            else{

                return;
            }

            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);

        }
    }

    [PunRPC]
    public void DestroyObjectRPC(){

        // null 체크 후 카메라가 assign 된 경우 
        if(gameObject.GetComponent<Movement>().cam){

            gameObject.GetComponent<Movement>().cam.transform.gameObject.SetActive(false);
        } 

        Destroy(gameObject);
    }
}
