using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    private WaitForSeconds _damageCooldownTime;

    private void Start()
    {
        _damageCooldownTime = new WaitForSeconds(0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hit = collision.GetComponent<IDamageable>();
        if (hit != null && _canDamage == true)
        {
            StartCoroutine(DamageCooldown());
            hit.Damage();
        }
    }


    private IEnumerator DamageCooldown()
    {
        _canDamage = false;
        yield return _damageCooldownTime;
        _canDamage = true;
    }
}
