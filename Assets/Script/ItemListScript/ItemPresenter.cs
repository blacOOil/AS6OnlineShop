using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Inventory.ItemPresenter
{

    public class ItemPresenter : MonoBehaviour
    {
        /////////////////////////////////////////////
        int currentCategoryIndex;
        int maxShownItemCount;
        /////////////////////////////////////////////
        public TextMeshProUGUI ItemTextUi;

        [SerializeField] public List<Item> Items = new List<Item>();
        [SerializeField] ItemArray inventory;
        [SerializeField] public Transform ItemContent;
        [SerializeField] public GameObject ShopItemPrefab;
      
      
        public void Start()
        {
            CategorizeItems();
            RefreshUI();
            //ListItem();
        }

        private void Awake()
        {

        }

        public void ListItem()
        {
            foreach (var item in Items)
            {
                GameObject itemUi = Instantiate(ShopItemPrefab, ItemContent);

                itemUi.transform.Find("Image").GetComponent<Image>().sprite = item.Icon;
                ItemTextUi = itemUi.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
                ItemTextUi.text = item.ItemName;
            }
        }

        public void WeaponCategory() {
            currentCategoryIndex = 0;
            RefreshUI();
            Debug.Log("0 - Weapon");
        }
        public void HealCategory() {
            currentCategoryIndex = 1;
            RefreshUI();
            Debug.Log("1 - Heal");
        }
        public void ResourceCategory() {
            currentCategoryIndex = 2;
            RefreshUI();
            Debug.Log("2 - Resource");
        }
        public void GemCategory() {
            currentCategoryIndex = 3;
            RefreshUI();
            Debug.Log("3 - Gem");
        }
        public void CharacterStarCategory() {
            currentCategoryIndex = 4;
            RefreshUI();
            Debug.Log("4 - CharacterStar");
        }

        void RefreshUI()
        {
            // Clear the existing UI content
            foreach (Transform child in ItemContent)
            {
                Destroy(child.gameObject);
            }

            // Get the currently selected category
            ItemType selectedCategory = (ItemType)currentCategoryIndex;

            // Populate the UI with items from the selected category
            foreach (var item in Items)
            {
                if (item.type == selectedCategory)
                {
                    GameObject itemUi = Instantiate(ShopItemPrefab, ItemContent);
                    itemUi.transform.Find("Image").GetComponent<Image>().sprite = item.Icon;
                    TextMeshProUGUI itemTextUi = itemUi.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
                    itemTextUi.text = item.ItemName;
                }
            }
        }

        private void CategorizeItems()
        {
            foreach (var item in Items)
            {
                switch (item.type)
                {
                    case ItemType.Weapon:
                        item.type = ItemType.Weapon;
                        break;
                    case ItemType.Heal:
                        item.type = ItemType.Heal;
                        break;
                    case ItemType.Resource:
                        item.type = ItemType.Resource;
                        break;
                    case ItemType.Gem:
                        item.type = ItemType.Gem;
                        break;
                    case ItemType.CharacterStar:
                        item.type = ItemType.CharacterStar;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
