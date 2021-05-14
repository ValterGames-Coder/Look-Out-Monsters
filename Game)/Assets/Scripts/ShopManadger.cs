using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManadger : MonoBehaviour
{
    public Text ShopText;

    void Update()
    {
        ShopText.text = PlayerPrefs.GetInt("MoneyShop").ToString();
    }
}
