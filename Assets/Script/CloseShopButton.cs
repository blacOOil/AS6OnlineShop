using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloseShopButton : MonoBehaviour
{
    public static bool CloseShopActive = false;
    
    [SerializeField] public GameObject OldCanvasUI;
    [SerializeField] public GameObject NewCanvasUI;
    [SerializeField] public GameObject Scrollbar;
    [SerializeField] public GameObject Text;
    [SerializeField] public CanvasGroup CanvasGroup;
    private Tween fadeTween;

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

            HidingUI();
            
            NewCanvasUI.SetActive(false);
            OldCanvasUI.SetActive(false);
            Scrollbar.SetActive(false);
            
            Text.SetActive(true);
            
            CloseShopActive = true;

            Debug.Log("Off");
        } 
        else if (CloseShopActive == true) {

            UnHidingUI();
            NewCanvasUI.SetActive(true);
            OldCanvasUI.SetActive(false);
            Scrollbar.SetActive(true);
            Text.SetActive(false);

            CloseShopActive = false;
            Debug.Log("on");
        }
    }
    public void FadIn(float durtion)
    {
        Fade(1f, durtion, () => {
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
        });
    }
    public void FadOut(float durtion)
    {
        Fade(0f, durtion, () => {
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        });
    }
    public void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }
        fadeTween = CanvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    private IEnumerator HideUI()
    {
        
        yield return new WaitForSeconds(0.1f);
        FadOut(1f);
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator UnHide()
    {

        yield return new WaitForSeconds(0.4f);
        FadIn(0.7f);
        yield return new WaitForSeconds(0.4f);
    }
    public void HidingUI()
    {
        StartCoroutine(HideUI());
    }
    public void UnHidingUI()
    {
        StartCoroutine(UnHide());
    }
    
}
