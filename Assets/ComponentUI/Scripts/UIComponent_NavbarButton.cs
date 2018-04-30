using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIComponent_NavbarButton : UIComponent, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

    Image background;
    Image icon;

    public override void Start()
    {
        background = GetComponent<Image>();
        icon = transform.GetChild(0).GetComponent<Image>();

    }

  

    public void OnPointerEnter(PointerEventData eventData)
    {
        //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseEnterButton);
        icon.color = skinData.radialActionButtonHoverIconBackColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseDownButton);
        background.color = skinData.radialActionButtonHoverIconBackColor;
        icon.color = skinData.radialActionButtonHoverIconColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseExitButton);
        icon.color = skinData.radialActionButtonDefaultIconColor;
        background.color = skinData.radialActionButtonDefaultIconBackColor;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerExit(eventData);

    }
}
