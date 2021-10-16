using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private PlayerAnimation _playerAnim;
    private Rigidbody2D _rb;
    private SpriteRenderer _renderer;
    private SpriteRenderer _swordArc;

    public int Health { get; set; }

    void Start()
    {
        _playerAnim = GetComponent<PlayerAnimation>();
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _swordArc = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
        CheckForAttack();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && IsGrounded() == true)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
        ControlPlayerSpriteAndAnimations(horizontalInput);
    }

    private void CheckForAttack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
            _playerAnim.Attack();
    }

    private void ControlPlayerSpriteAndAnimations(float input)
    {
        FlipPlayerSprite(input);
        _playerAnim.Move(input);
        bool isJumping = !IsGrounded();
        _playerAnim.Jump(isJumping);
    }

    private void FlipPlayerSprite(float input)
    {
        if (input != 0)
            _renderer.flipX = input < 0 ? true : false;

        if(_renderer.flipX == true)
        {
            _swordArc.flipX = true;
            _swordArc.flipY = true;
            Vector3 newPosition = _swordArc.transform.localPosition;
            newPosition.x = -1.01f;
            _swordArc.transform.localPosition = newPosition;
        }
        else
        {
            _swordArc.flipX = false;
            _swordArc.flipY = false;
            Vector3 newPosition = _swordArc.transform.localPosition;
            newPosition.x = 1.01f;
            _swordArc.transform.localPosition = newPosition;
        }
    }

    bool IsGrounded()
    {
        bool raycast = Physics2D.Raycast(transform.position, -Vector2.up, 1f, _groundLayer);
        if (raycast == true)
            return true;
        return false;
    }

    public void Damage()
    {
        Debug.Log("My Leg");
    }
}
