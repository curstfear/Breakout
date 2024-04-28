using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float _speed;
    private Rigidbody2D _rb;
    Vector3 movement;
    private bool _isBlock;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        MoveLogic();
    }

    void MoveLogic()
    {
        _rb.velocity = Vector3.zero;
        float moveInput = Input.GetAxis("Horizontal");
        movement = new Vector2(moveInput, 0f) * _speed;
        transform.position += movement;

        /*moveInput.x = Input.GetAxis("Horizontal");
        _rb.MovePosition(_rb.position + moveInput * _speed * Time.fixedDeltaTime);*/  
        
    }
}
