using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Trigger : MonoBehaviour
{
    [SerializeField] private GameObject _winStatusPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(GameManager.Instance.HasKeyToCastle == true)
            {
                //main menu
            }
            else
            {
                _winStatusPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _winStatusPanel.SetActive(false);
        }
    }
}
