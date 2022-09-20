using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            //kill
            Destroy(transform.parent.gameObject); 
            //몬스터가 Ai라는 부모의 자식으로 있으니까 모든 오브젝트를 삭제하기 위해 부모 오브젝트를 삭제함
        }
    }
}