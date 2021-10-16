using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }
    public void Damage()
    {
        Health--;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Destroy(GetComponent<BoxCollider2D>());
            GameObject spawnedDiamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            spawnedDiamond.GetComponent<Diamond>().value = gems;
        }
    }
}
