using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchUIBotton : MonoBehaviour
{
    public static bool NewCanvasUiActive = false;
    
    public GameObject OldCanvasUI;
    public GameObject NewCanvasUI;
    public Scrollbar target;

    // Update is called once per frame
    void Update() {
        if (target.value == 0f) {
            CanvasUISwitchNew();
        } else if (target.value == 1f) {
            CanvasUISwitchOld();
        }
    }

    public void CanvasUISwitchNew() {
        NewCanvasUI.SetActive(true);
        OldCanvasUI.SetActive(false);
        NewCanvasUiActive = true;
        Debug.Log("ItemInfo Pop-up");
    }

    public void CanvasUISwitchOld() {
        NewCanvasUI.SetActive(false);
        OldCanvasUI.SetActive(true);
        NewCanvasUiActive = false;
        Debug.Log("ItemInfo Pop-down");
    }

    
}
