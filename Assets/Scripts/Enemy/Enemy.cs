using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;
    protected Transform player;

    protected Animator anim;
    protected bool canFlipSprite;
    protected bool isHit;
    protected Transform targetPosition;
    protected SpriteRenderer spriteRenderer;

    public virtual void Init()
    {
        player = GameObject.Find("Player").transform;
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        targetPosition = pointA;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        Movement();
    }

    public virtual void Movement()
    {
        if (isHit == true)
        {
            float playerDistance = Vector2.Distance(transform.position, player.transform.position);
            if (playerDistance > 3)
            {
                isHit = false;
                anim.SetBool("InCombat", false);
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true || isHit == true)
            return;

        if (canFlipSprite == true)
        {
            canFlipSprite = false;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        float distance = Vector2.Distance(transform.position, targetPosition.position);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        if (distance < 0.3f)
        {
            targetPosition = spriteRenderer.flipX == true ? targetPosition = pointB : targetPosition = pointA;
            anim.SetTrigger("Idle");
            canFlipSprite = true;
        }
    }

    protected virtual void Attack()
    {

    }
}
