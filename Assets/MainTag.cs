using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTag : MonoBehaviour
{
    public List<ButtonTag> buttonTagList;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;

    public ButtonTag ChossTag;

public List<GameObject> objectsToSwap;
    public void Sub(ButtonTag button)
    {
        if (buttonTagList == null)
        {
            buttonTagList = new List<ButtonTag>();
        }

        buttonTagList.Add(button);
    }

    public void EnterTab(ButtonTag button)
    {
        ResetTab();
        if (ChossTag == null || button != ChossTag)
        button.background.sprite = tabHover;
    }

    public void ExitTab(ButtonTag button)
    {
        ResetTab();
    }

    public void SelectTab(ButtonTag button)
    {
        ChossTag = button;
        ResetTab();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i=0; i<objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTab()
    {
        foreach (ButtonTag button in buttonTagList)
        {
            if(ChossTag != null && button == ChossTag) { continue; }
            button.background.sprite = tabIdle;
        }
    }
}
