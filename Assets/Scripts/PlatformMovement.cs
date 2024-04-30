using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _isBlock;
    Vector3 movement;

    private Rigidbody2D _rb;

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
    }
}
