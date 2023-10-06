using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopButton : MonoBehaviour
{
    public static bool CloseShopActive = false;
    
    [SerializeField] public GameObject OldCanvasUI;
    [SerializeField] public GameObject NewCanvasUI;
    [SerializeField] public GameObject Scrollbar;
    [SerializeField] public GameObject Text;

    // Update is called once per frame
    void Update() {
        // if (CloseShopActive == true) {
        //     CloseShopOn();
        // } else {
        //     CloseShopOff();
        // }
    }

    public void CloseShopOff(bool StatusShop) {
        if (CloseShopActive == false) {
            NewCanvasUI.SetActive(false);
            OldCanvasUI.SetActive(false);
            Scrollbar.SetActive(false);
            Text.SetActive(true);
            
            CloseShopActive = true;
            Debug.Log("Off");
        } 
        else if (CloseShopActive == true) {
            NewCanvasUI.SetActive(true);
            OldCanvasUI.SetActive(false);
            Scrollbar.SetActive(true);
            Text.SetActive(false);

            CloseShopActive = false;
            Debug.Log("on");
        }
    }
}
