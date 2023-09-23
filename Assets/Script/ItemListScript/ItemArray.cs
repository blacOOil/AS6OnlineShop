using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Inventory.ItemPresenter
{
    public class ItemArray : MonoBehaviour
    {
        
        public Item[] Items1 => Items.ToArray();
        [SerializeField] List<Item> Items = new List<Item>();
      

        public Item[] GetItemsByType(ItemType targetType)
        {

            var resultlist = new List<Item>();
            foreach(var Item in Items)
            {
                if(Item.type == targetType)
                {
                    if(Item.type == targetType)
                        resultlist.Add(Item);
                        
                    
                } 
            }
            return resultlist.ToArray();
        }     
    }
  
    [System.Serializable]
    public class Item
    {
        
        public Sprite Icon;
        public string ItemName;
        public string ItemInfo;
        public float Price;
        public ItemType type;
        public string order;
     
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
