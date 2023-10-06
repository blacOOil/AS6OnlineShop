using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

namespace Inventory.ItemPresenter
{
    public class ItemArray : MonoBehaviour
    {
        
        // public ItemIcon[] itemIcon => itemsIconJson.ToArray();
        // [SerializeField] public List<ItemIcon> itemsIconJson = new List<ItemIcon>();

        /// /////////////////////////////////////////////////////////////////////////////// <summary>

        // public Item[] Items1 => Items.ToArray();
        // [SerializeField] public List<Item> Items = new List<Item>();
      

        // public Item[] GetItemsByType(ItemType targetType)
        // {

        //     var resultlist = new List<Item>();
        //     foreach(var Item in Items)
        //     {
        //         if(Item.type == targetType)
        //         {
        //             if(Item.type == targetType)
        //             // foreach(var ItemIcon in itemsIconJson)
        //             // {
        //             //     if(Item.ItemName == ItemIcon.itemName)
        //             //     {
        //             //     Item.Icon = ItemIcon.icon;
        //             //     }
        //             // }
                        
                    
        //             resultlist.Add(Item);
        //         } 
        //     }
        //     return resultlist.ToArray();
        // }     
    }
  
    [Serializable]
    public class Item
    {
        
        public Sprite Icon;
        public string ItemName;
        public string ItemInfo;
        public float Price;
        public ItemType type;
        public int order;
     
    }

    [Serializable]
    public class ItemIcon
    {
       public Sprite icon;
       public string itemName;
    }
    
    public enum ItemType
    {
        Weapon,
        Heal,
        Resource,
        Gem,
        CharacterStar
    }


}
