using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Animator _anim;
    private bool _canFlipSprite;
    private Transform _targetPosition;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _targetPosition = pointA;
    }
    public override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true)
            return;

        if (_canFlipSprite == true)
        {
            _canFlipSprite = false;
            _renderer.flipX = _targetPosition.position == pointA.position ? true : false;
        }

        float distance = Vector2.Distance(transform.position, _targetPosition.position);
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition.position, speed * Time.deltaTime);

        if (distance < 1)
        {
            _targetPosition = _renderer.flipX == true ? _targetPosition = pointB : _targetPosition = pointA;
            _anim.SetTrigger("Idle");
            _canFlipSprite = true;
        }
    }
}
