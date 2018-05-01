using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    public class ComponentUI_Dropdown : ComponentUICore
    {

        [SerializeField]
        Text labelText;

        [SerializeField]
        Image dropIcon;

        [SerializeField]
        Image templateSkin;

        [SerializeField]
        Image scrollBack;

        [SerializeField]
        Image scrollHandle;

        [SerializeField]
        Toggle option;

        [SerializeField]
        Image optionBackground;

        [SerializeField]
        Text optionLabel;




        public override void SkinObject()
        {
            body.sprite = skinData.dropdownBoxLabelSkin;
            body.GetComponent<Dropdown>().colors = skinData.dropdownBoxLabelColors;

            dropIcon.color = skinData.dropdownIconColor;
            dropIcon.sprite = skinData.dropdownIcon;

            if (labelText != null)
            {
                labelText.color = skinData.dropdownBoxLabelTextColor;

            }

            templateSkin.sprite = skinData.dropdownBoxBackgroundSprite;
            templateSkin.color = skinData.dropdownBoxBackgroundColor;

            scrollBack.sprite = skinData.scrollSkinSprite;
            scrollBack.color = skinData.scrollSkinColor;

            scrollHandle.sprite = skinData.scrollHandleSprite;
            scrollHandle.color = skinData.scrollHandleColor;

            if (optionLabel != null)
            {
                optionLabel.color = skinData.dropdownOptionTextColor;
            }
            optionBackground.sprite = skinData.dropdownOptionSprite;
            option.colors = skinData.dropdownOptionColors;
        }
    }
}
