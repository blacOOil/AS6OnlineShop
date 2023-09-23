using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class ButtonTag : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public MainTag mainTag;
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        mainTag.SelectTab(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mainTag.EnterTab(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mainTag.ExitTab(this);
    }

    void Start()
    {
        background = GetComponent<Image>();
        mainTag.Sub(this);
    }

    void Update()
    {
    }
}
