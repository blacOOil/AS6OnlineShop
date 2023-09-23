using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Inventory.ItemData;

 public class ItemUI : MonoBehaviour
{
    
    public Transform ContentContainer;
    public Transform ItemPrefab;

    public List<ItemScript> ItemScripts = new List<ItemScript>();
    private void Start()
    {
        
    }
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateItemOnScreen(Sprite Icon , string ItemName, string ItemInfo)
    {
        Transform ItemPrefabTranform = Instantiate(ItemPrefab, ContentContainer);
        ItemPrefabTranform.gameObject.SetActive(true);

    }
}
