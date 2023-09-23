using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonInfo : MonoBehaviour
{
    public int ItemName;
    public Text MoneySell;
    public Text Amount;
    
    public GameObject ShopManager;
    void Start()
    {
   //     MoneySell.text = "Gem : " + ShopManager.GetComponent<ShopManagerscript>().shopItem[2,ItemName].ToString();
     //   Amount.text = ShopManager.GetComponent<ShopManagerscript>().shopItem[3,ItemName].ToString();
    }
}
