using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Networking;
using TMPro;
using System.IO;
using DG.Tweening;


namespace Inventory.ItemPresenter
{

    public class ItemPresenter : MonoBehaviour
    {
        /////////////////////////////////////////////
        int currentCategoryIndex;
        int maxShownItemCount;
        /////////////////////////////////////////////
        
        [Header("Online-Save")]
        [SerializeField] string userinfo;
        [SerializeField] string loadinfo;

        public TextMeshProUGUI ItemTextUi;

        [SerializeField] public List<Item> Items = new List<Item>();

        /////////////////////////////////////////////
        public ItemIcon[] itemIcon => itemsIconJson.ToArray();
        [SerializeField] public List<ItemIcon> itemsIconJson = new List<ItemIcon>();
        /////////////////////////////////////////////
        [SerializeField] ItemArray inventory;
        [SerializeField] Transform ItemContent;
        [SerializeField] GameObject ShopItemPrefab;
      

        private void Awake()
        {
            LoadScoreFromGoogleDrive();
        }
        
        public void Start()
        {
            CategorizeItems();
            RefreshUI();
            //ListItem();
        }

        // public void ListItem()
        // {
        //     foreach (var item in Items)
        //     {
        //         GameObject itemUi = Instantiate(ShopItemPrefab, ItemContent);

        //         itemUi.transform.Find("Image").GetComponent<Image>().sprite = item.Icon;
        //         ItemTextUi = itemUi.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        //         ItemTextUi.text = item.ItemName;
        //     }
        // }

        public Item[] GetItemsByType(ItemType targetType) {
            var resultlist = new List<Item>();
            foreach(var Item in Items) {
                if(Item.type == targetType) {
                    if(Item.type == targetType)
                    foreach(var ItemIcon in itemsIconJson) {
                        if(Item.ItemName == ItemIcon.itemName) {
                        Item.Icon = ItemIcon.icon;
                        }
                    }
                    resultlist.Add(Item);
                } 
            }
            return resultlist.ToArray();
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
                    itemUi.GetComponentInChildren<Image>().sprite = item.Icon;
                    itemUi.GetComponentInChildren<TMP_Text>().text = item.ItemName;
                  
                    
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

        [ContextMenu(nameof(SaveScoreData))]
        void SaveScoreData()
        {
            if (string.IsNullOrEmpty(userinfo))
            {
                Debug.Log("NO SAVE!");
                return;
            }

            var scoreJson = JsonConvert.SerializeObject(ItemContent, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var dataPath = Application.dataPath;
            var targetFilePath = Path.Combine(dataPath, userinfo);

            var directoryPath = Path.GetDirectoryName(targetFilePath);
            if (Directory.Exists(directoryPath) == false)
                Directory.CreateDirectory(directoryPath);

            File.WriteAllText(targetFilePath, scoreJson);
        }
        IEnumerator LoadDataRoutine(string url)
        {
            var webRequest = UnityWebRequest.Get(url);
            //Get download progress
            var progress = webRequest.downloadProgress;
            Debug.Log(progress);

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                var downloadedText = webRequest.downloadHandler.text;
                Items = JsonConvert.DeserializeObject<List<Item>>(downloadedText);
                for (int numberofcurrentItems = 0 ; numberofcurrentItems < Items.Count ; numberofcurrentItems++) {
                    foreach (var itemIcon in itemsIconJson) {
                        if (itemIcon.itemName == Items[numberofcurrentItems].ItemName) {
                            Items[numberofcurrentItems].Icon = itemIcon.icon;
                        } 
                    }
                }
            }
            RefreshUI();
        }
         [ContextMenu(nameof(LoadScoreFromGoogleDrive))]
        void LoadScoreFromGoogleDrive()
        {
            StartCoroutine(LoadDataRoutine(loadinfo));
        }
    }
}