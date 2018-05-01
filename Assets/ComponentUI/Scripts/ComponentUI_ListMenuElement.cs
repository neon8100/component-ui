using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ComponentUI.Base
{
    /// <summary>
    /// This is a menu element for list elements with headers.
    /// </summary>
    public class ComponentUI_ListMenuElement : ComponentUICore
    {
        [SerializeField]
        Image control;

        [SerializeField]
        bool colorOverride;
        [SerializeField]
        Color bodyColor;
        [SerializeField]
        Color controlColor;

        [Header("Generics")]
        public Image icon;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI valueText;

        public override void SkinObject()
        {
            if (skinData == null) return;

            if (!colorOverride)
            {
                body.color = skinData.menuItemTextBackgroundColor;
                control.color = skinData.menuItemControlBackgroundColor;
            }
            else
            {
                body.color = bodyColor;
                control.color = controlColor;
            }

        }
    }
}
