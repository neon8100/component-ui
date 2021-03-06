﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    /// <summary>
    /// This script controls List Items
    /// </summary>
    public class ComponentUI_ListItemButton : ComponentUICore, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {

        [SerializeField]
        protected Graphic[] hoverItems;

        [SerializeField]
        bool skinOverride;

        [SerializeField]
        ColorBlock colors;

        public override void SkinObject()
        {
            base.SkinObject();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            foreach (Graphic item in hoverItems)
            {
                SetColor(item, colors.pressedColor);
            }

            if (onClickAction != null)
            {
                onClickAction.Invoke();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            foreach (Graphic item in hoverItems)
            {
                SetColor(item, colors.highlightedColor);
            }

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            foreach (Graphic item in hoverItems)
            {
                SetColor(item, colors.normalColor);
            }
        }


        protected UnityAction onClickAction;
        public void OnClick(UnityAction action)
        {
            onClickAction = action;
        }


        public void SetColor(Graphic item, Color color)
        {

            item.color = color;
        }
    }
}
