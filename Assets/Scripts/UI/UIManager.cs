using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI Manager Is Null");
            }
            return _instance;
        }
    }

    public Text shopGemCountText;
    public Text hudGemCountText;
    public Image selectionImage;
    public GameObject[] lifeUnits;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        shopGemCountText.text = gemCount + "G";
    }

    public void UpdateShopSelection(float yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        hudGemCountText.text = count + "G";
    }

    public void UpdateHealthBar(int health)
    {
        switch (health)
        {
            case 0:
                lifeUnits[0].SetActive(false);
                lifeUnits[1].SetActive(false);
                lifeUnits[2].SetActive(false);
                lifeUnits[3].SetActive(false);
                break;
            case 1:
                lifeUnits[0].SetActive(false);
                lifeUnits[1].SetActive(false);
                lifeUnits[2].SetActive(false);
                lifeUnits[3].SetActive(true);
                break;

            case 2:
                lifeUnits[0].SetActive(false);
                lifeUnits[1].SetActive(false);
                lifeUnits[2].SetActive(true);
                lifeUnits[3].SetActive(true);
                break;
            case 3:
                lifeUnits[0].SetActive(false);
                lifeUnits[1].SetActive(true);
                lifeUnits[2].SetActive(true);
                lifeUnits[3].SetActive(true);
                break;
        }
    }
}
