using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] private GameObject _acidPrefab;
    [SerializeField] private Transform _acidSpawnLocation;

    public int Health {get; set;}

    public override void Movement()
    {
        //Spider Does Not Move
    }

    public override void Update()
    {
        
    }

    public void Attack()
    {
        Instantiate(_acidPrefab, _acidSpawnLocation.position, transform.rotation);
    }

    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
