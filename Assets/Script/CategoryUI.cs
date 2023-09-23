using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Inventory.ItemPresenter
{
    public class CategoryUI : MonoBehaviour
    {
        ItemPresenter itemPresenter;
        public static bool CategoryActive = false;
        public GameObject CategoryItem;

        // Update is called once per frame
        void Update()
        {
            if (CategoryActive == true) {
                ShowCategory();
            } else {
                ShowCategoryOff();
            }
        }

        public void ShowCategory() {
            CategoryItem.SetActive(true);
            CategoryActive = true;
            // itemPresenter.WeaponCategory();
            // itemPresenter.HealCategory();
            // itemPresenter.ResourceCategory();
            // itemPresenter.HealCategory();
            // itemPresenter.GemCategory();
            // itemPresenter.CharacterStarCategory();
        }

        public void ShowCategoryOff() {
            CategoryItem.SetActive(false);
            CategoryActive = false;
        }
    }
}
