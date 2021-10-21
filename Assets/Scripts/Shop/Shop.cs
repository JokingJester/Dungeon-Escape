using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopUI;
    [SerializeField] private GameObject _loadADPanel;
    public int _selectedItem;
    public Player _player;


    private void Start()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
                _player = player;
            }
            _shopUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _shopUI.SetActive(false);
            _loadADPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(67.72f);
                _selectedItem = 0;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-34.14f);
                _selectedItem = 1;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-133.23f);
                _selectedItem = 2;
                break;
        }
    }

    public void BuyItem()
    {
        switch (_selectedItem)
        {
            case 0:
                if(_player.diamonds >= 200)
                {
                    UIManager.Instance.UpdateAdStatusText("YOU UNLOCKED FLAME SWORD");
                    _player.UnlockFireSword(200);
                }
                break;
            case 1:
                if(_player.diamonds >= 400)
                    _player.UnlockBootsOfFlight(400);
                break;
            case 2:
                if(_player.diamonds >= 100 && GameManager.Instance.HasKeyToCastle == false)
                {
                    UIManager.Instance.UpdateAdStatusText("YOU UNLOCKED KEY TO CASTLE");
                    _player.diamonds -= 100;
                    GameManager.Instance.HasKeyToCastle = true;
                }
                break;
        }
        UIManager.Instance.OpenShop(_player.diamonds);
        UIManager.Instance.UpdateGemCount(_player.diamonds);
    }
}
