using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    [ExecuteInEditMode]
    public class ComponentUI_RadialActionButton : ComponentUICore, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {

        Button button;
        public Button baseButton
        {
            get
            {
                if (button == null) { button = GetComponent<Button>(); }
                return button;
            }
        }

        [SerializeField]
        Text buttonText;
        public void SetText(string text)
        {
            buttonText.text = text;
        }

        [SerializeField]
        Image buttonArea;
        [SerializeField]
        Image imageIconBox;
        [SerializeField]
        Image imageIconIcon;

        bool over;

        [SerializeField]
        Sprite defaultSprite;


        public UnityEvent onMouseEnter = new UnityEvent();
        public UnityEvent onMouseExit = new UnityEvent();

        public bool interactable
        {
            get
            {
                return baseButton.interactable;
            }
            set
            {
                baseButton.interactable = value;
                SkinObject();
            }
        }

        public void SetIcon(Sprite icon)
        {
            if (icon == null)
            {
                imageIconIcon.gameObject.SetActive(false);
                return;
            }

            imageIconIcon.sprite = icon;
        }

        public Text text;

        public override void Awake()
        {
            button = GetComponent<Button>();
            base.Awake();
        }

        public override void SkinObject()
        {
            if (over) { return; }
            if (!imageIconBox.isActiveAndEnabled)
            {
                buttonArea.sprite = GetComponent<Image>().sprite;
            }
            else
            {
                buttonArea.sprite = defaultSprite;
            }

            base.SkinObject();


            buttonText.color = interactable ? skinData.radialActionButtonDefaultTextColor : skinData.radialActionButtonDisabledTextColor;
            buttonArea.color = interactable ? skinData.radialActionButtonDefaultBaseColor : skinData.radialActionButtonDisabledBaseColor;
            imageIconBox.color = interactable ? skinData.radialActionButtonDefaultIconBackColor : skinData.radialActionButtonDisabledIconBackColor;
            imageIconIcon.color = interactable ? skinData.radialActionButtonDefaultIconColor : skinData.radialActionButtonDisabledIconColor;
        }



        public void OnPointerEnter(PointerEventData b)
        {
            if (!interactable) { return; }

            //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseEnterButton);
            over = true;
            buttonText.color = skinData.radialActionButtonHoverTextColor;
            buttonArea.color = skinData.radialActionButtonHoverBaseColor;
            imageIconBox.color = skinData.radialActionButtonHoverIconBackColor;
            imageIconIcon.color = skinData.radialActionButtonHoverIconColor;

            onMouseEnter.Invoke();
        }

        public void OnPointerExit(PointerEventData p)
        {
            if (!interactable) { return; }

            //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseExit);
            over = false;

            buttonText.color = skinData.radialActionButtonDefaultTextColor;
            buttonArea.color = skinData.radialActionButtonDefaultBaseColor;
            imageIconBox.color = skinData.radialActionButtonDefaultIconBackColor;
            imageIconIcon.color = skinData.radialActionButtonDefaultIconColor;

            onMouseExit.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable) { return; }

            //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseDownButton);
        }
    }
}
