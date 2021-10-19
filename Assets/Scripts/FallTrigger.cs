using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private Vector2 _playerSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        _playerSpawnPos = new Vector2(0.82f, 0.7f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();
            if(hit != null)
            {
                hit.Damage();
                collision.gameObject.transform.position = _playerSpawnPos;
            }
        }
    }
}
