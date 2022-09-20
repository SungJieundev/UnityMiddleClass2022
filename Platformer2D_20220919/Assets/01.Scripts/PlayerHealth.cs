using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int _healthPoints = 5;
    public Image[] _heart;
    public Sprite _emptyHeart;

    private Rigidbody2D _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();    
    }

    void Damage(){
        _healthPoints -= 1;
        _heart[_healthPoints].sprite = _emptyHeart;
    }

    private void OnCollisionEnter2D(Collision2D other) {
         if(other.collider.CompareTag("Enemy")){
            Damage();
        }
    }

    IEnumerator KnockBack(float knockBackTime, float knockBackPower){

        float timer = 0f;
        while (knockBackTime > timer){
            timer += Time.deltaTime;
            _rb.AddForce(new Vector2(transform.position.x * -50f, transform.position.y + knockBackPower));
        }
        yield return 0;
    }
}
