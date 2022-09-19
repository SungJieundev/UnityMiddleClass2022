using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed;
    public float _jumpHeight;
    Vector2 _moveDir;
    Vector2 _velocity;
    Vector2 _playerMovement;

    public Rigidbody2D _rb;
    public float _gravity = -9.81f;

    bool _isGrounded;
    public Transform _groundCheck;
    public LayerMask _whatIsGround;

    public Animator _animator;


    private void Update() {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _whatIsGround);

        if(_isGrounded && _velocity.y <= 0f){
            _velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && _isGrounded == true){
            // 루트 2 * v * h 
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);  
        }

        _moveDir.x = Input.GetAxis("Horizontal");
        _animator.SetFloat("Move", Mathf.Abs(_moveDir.x));

        _velocity.y += _gravity * Time.deltaTime;
        _playerMovement = new Vector2(_moveDir.x * (_speed * 10f), _velocity.y);

        if(_moveDir.x > 0f){
            transform.localScale = new Vector2(-1, 1);
        }
        if(_moveDir.x < 0f){
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void FixedUpdate() {
        _rb.velocity = _playerMovement * Time.fixedDeltaTime;
    }
}
