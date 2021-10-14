using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Animator _anim;
    private bool _canFlip;
    private SpriteRenderer _renderer;
    private Transform _targetPos;

    private void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();
        _targetPos = pointA;
    }
    public override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == false)
        {
            if (_canFlip == true)
            {
                _canFlip = false;
                _renderer.flipX = !_renderer.flipX;
            }

            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, speed * Time.deltaTime);
            float distance = Vector2.Distance(transform.position, _targetPos.position);

            if (distance < 0.1f)
            {
                if (_targetPos.position == pointA.position)
                    _targetPos = pointB;
                else
                    _targetPos = pointA;

                _anim.SetTrigger("Idle");
                _canFlip = true;
            }
        }
    }
}
