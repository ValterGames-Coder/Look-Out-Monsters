using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int Money;
    public float speed;
    public Text money;
    public GameObject ShopPanel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PanelShopOn()
    {
        Time.timeScale = 0;
        ShopPanel.SetActive(true);
    }

    public void PanelShopOff()
    {
        Time.timeScale = 1;
        ShopPanel.SetActive(false);
    }

}
