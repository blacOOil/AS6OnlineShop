using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public static bool ItemInfoIsPaused = false;
  
    public GameObject itemInfoUI;

    // Update is called once per frame
    void Update() {
        if (ItemInfoIsPaused == true) {
            ItemInfoUIIn();
            //Debug.Log("ItemInfo Pop-up");
        } else {
            ItemInfoUIOut();
            //Debug.Log("ItemInfo Pop-down");
        }

        ESCButton();
    }

    public void ItemInfoUIOut() {
        itemInfoUI.SetActive(false);
        Time.timeScale = 1f;
        ItemInfoIsPaused = false;
        Debug.Log("ItemInfo Pop-down");
    }

    public void ItemInfoUIIn() {
        itemInfoUI.SetActive(true);
        Time.timeScale = 0f;
        ItemInfoIsPaused = true;
        Debug.Log("ItemInfo Pop-up");
    }

    public void Buy() {

        ItemInfoUIOut();
    }

    public void Cancel() {
        ItemInfoUIOut();
    }

    public void ESCButton() {
        if (Input.GetButton("Escape") || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A)) {
            itemInfoUI.SetActive(false);
            Time.timeScale = 1f;
            ItemInfoIsPaused = false;
            Debug.Log("Esc");
        }

    }
}
