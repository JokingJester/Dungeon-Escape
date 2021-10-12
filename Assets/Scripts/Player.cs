using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && IsGrounded() == true)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    bool IsGrounded()
    {
        bool raycast = Physics2D.Raycast(transform.position, -Vector2.up, 1f, _groundLayer);
        if (raycast == true)
            return true;
        return false;
    }
}
