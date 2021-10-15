using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public override void Movement()
    {
        base.Movement();
        var playerDirection = transform.position - player.position;
        if(anim.GetBool("InCombat") == true)
        {
            if(resetSpriteRendererFlip == false)
            {
                resetSpriteRendererFlip = true;
                spriteRendererFlipStatus = spriteRenderer.flipX;
            }
            if(playerDirection.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }
    public void Damage()
    {
        Health--;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        isHit = true;
        if(Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
