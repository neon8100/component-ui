using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIComponent_Button : UIComponent, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

    private Button m_Button;
    protected Button button
    {
        get
        {
            if(m_Button == null)
            {
                m_Button = GetComponent<Button>();
            }
            return m_Button;
        }
    }

    [SerializeField]
    ButtonType buttonType;

    [SerializeField]
    bool wrap;

    [SerializeField]
    bool hasIcon;

    Image icon;
    
    [SerializeField]
    Sprite iconSprite;

    enum ButtonType
    {
        Accept,
        Decline,
        Warning,
        Default
        
    }

    public void SetTextKey(string key)
    {
        //transform.GetComponentInChildren<TextHandler>().ChangeKey(key);

    }

    public bool interactable { get { return button.interactable; } set { button.interactable = value; } }


    public override void Awake()
    {
        if (body == null)
        {
            body = GetComponent<Image>();
        }

        base.Awake();
    }

    public override void SkinObject()
    {

        if (icon == null && transform.Find("Icon")!=null)
        {
            icon = transform.Find("Icon").GetComponent<Image>();
        }

        if (GetComponent<ContentSizeFitter>() != null)
        {
            if (wrap)
            {
                GetComponent<ContentSizeFitter>().enabled = true;
            }
            else
            {
                GetComponent<ContentSizeFitter>().enabled = false;
            }
        }
    
        if (hasIcon && icon!=null)
        {
            icon.gameObject.SetActive(true);
            if (iconSprite != null)
            {
                icon.sprite = iconSprite;
            }
        }
        else
        {
            if (icon != null)
            {
                icon.gameObject.SetActive(false);
            }
        }

        switch (buttonType)
        {
            case ButtonType.Accept:
                button.colors = skinData.acceptButtonColors;
                break;
            case ButtonType.Decline:
                button.colors = skinData.declineButtonColors;
                break;
            case ButtonType.Warning:
                button.colors = skinData.warningButtonColors;
                break;
            case ButtonType.Default:
                button.colors = skinData.defaultButtonColors;
                break;
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseEnterButton);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseExit);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseDownButton);
    }

    public Button.ButtonClickedEvent onClick
    {
        get
        {
            return button.onClick;
        }
        set
        {
            button.onClick = value;
        }
    }

    



}
