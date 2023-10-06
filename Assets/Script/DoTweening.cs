using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweening : MonoBehaviour
{
    [SerializeField] public CanvasGroup canvasgruo;
    [SerializeField] public Transform Scroll_View, ItemPanel, ShopUI;
    [SerializeField] public float timing;
    private Tween fadeTween;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartFade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadIn(float durtion)
    {
        Fade(1f, durtion, () => {
            canvasgruo.interactable = true;
            canvasgruo.blocksRaycasts = true;
        });
    }
    public void FadOut(float durtion)
    {
        Fade(0f, durtion, () => {
            canvasgruo.interactable = false;
            canvasgruo.blocksRaycasts = false;
        });
    }
    public void Fade(float endValue,float duration,TweenCallback onEnd)
    {
        if(fadeTween != null)
        {
            fadeTween.Kill(false);
        }
        fadeTween = canvasgruo.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }
    private IEnumerator StartFade()
    {
     
        FadOut(0f);
        yield return new WaitForSeconds(0.5f);
        FadIn(0.3f);
        

    }
}
