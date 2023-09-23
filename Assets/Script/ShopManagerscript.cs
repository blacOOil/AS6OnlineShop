using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Inventory.ItemPresenter;


public class ShopManagerscript : MonoBehaviour
{

    [SerializeField] List<Item> shopItem = new List<Item>();
    public float Gem;
   public TextMeshProUGUI GemTXT;
   

    void Start()
    {
        GemTXT.text = "Gem:" + Gem.ToString();
       
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

       /*if (Gem >= shopItem[2,ButtonRef.GetComponent<ButtonInfo>().ItemName])
        {
            Gem = shopItem[2,ButtonRef.GetComponent<ButtonInfo>().ItemName];
            shopItem[3,ButtonRef.GetComponent<ButtonInfo>().ItemName]++;
            GemTXT.text = "Gem" + Gem.ToString();
            ButtonRef.GetComponent<ButtonInfo>().Amount.text = shopItem[3, ButtonRef.GetComponent<ButtonInfo>().ItemName].ToString();
        }   */ 

    }
}
