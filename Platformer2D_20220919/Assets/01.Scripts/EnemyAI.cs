using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private Vector2 _dir;

    private void Update() {
        _rigid.position += _dir * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Point")){
            //a와 b사이를 움직일거임 그래서 포인트에 닿으면 이동방향을 반대로 해줌
            _dir.x *= -1;
            transform.localScale = new Vector3(-_dir.x, 1, 1); //스프라이트 방향도 반대로 해주기 위해
        }
    }
}