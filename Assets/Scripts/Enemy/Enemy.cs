using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Animator anim;
    protected bool canFlipSprite;
    protected bool changeSpriteToOriginalFlipDirection;
    protected bool isDead;
    protected bool spriteRendererFlipDirection;
    protected Transform player;
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
        if(isDead == false)
            Movement();
    }

    public virtual void Movement()
    {
        //Flips sprite in the players direction in combat mode.
        var playerDirection = transform.position - player.position;
        if (anim.GetBool("InCombat") == true)
        {
            if (changeSpriteToOriginalFlipDirection == false)
            {
                changeSpriteToOriginalFlipDirection = true;
                spriteRendererFlipDirection = spriteRenderer.flipX;
            }
            spriteRenderer.flipX = playerDirection.x < 0 ? false : true;

            //Disables combat mode when the player is far away
            float playerDistance = Vector2.Distance(transform.position, player.transform.position);
            if (playerDistance > 3 && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") == false)
                anim.SetBool("InCombat", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true || anim.GetBool("InCombat") == true)
            return;//Doesn't run any code below when it is idle or in combat mode

        if (changeSpriteToOriginalFlipDirection == true)//Flips sprite in the direction it was in before combat mode
        {
            changeSpriteToOriginalFlipDirection = false;
            spriteRenderer.flipX = spriteRendererFlipDirection;
        }

        if (canFlipSprite == true)//Flips sprite in other direction after being idle
        {
            canFlipSprite = false;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        float distance = Vector2.Distance(transform.position, targetPosition.position);
        //Moves the enemy
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        if (distance < 0.3f)
        {
            //Sets the position to walk to based on how the sprite is flipped
            targetPosition = spriteRenderer.flipX == true ? targetPosition = pointB : targetPosition = pointA;
            anim.SetTrigger("Idle");
            canFlipSprite = true;
        }
    }
}
