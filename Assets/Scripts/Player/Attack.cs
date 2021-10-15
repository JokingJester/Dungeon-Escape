using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        IDamageable hit = collision.GetComponent<IDamageable>();
        if(hit != null)
        {
            hit.Damage();
        }
    }
}
