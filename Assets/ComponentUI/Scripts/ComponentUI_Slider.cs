using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    [RequireComponent(typeof(Slider))]
    public class ComponentUI_Slider : ComponentUICore
    {

        [SerializeField]
        Image fill;
        [SerializeField]
        Image handle;

        [SerializeField]
        bool isCustomHandle;

        [SerializeField]
        Color handleColor;

        [SerializeField]
        bool isCustomFill;
        [SerializeField]
        Color fillColor;

        public override void SkinObject()
        {
            base.SkinObject();

            body.sprite = skinData.baseImage;
            body.color = skinData.progressBarSkinBackgroundColor;

            if (isCustomFill)
            {
                fill.color = fillColor;
            }
            if (isCustomHandle)
            {
                handle.color = handleColor;
            }
        }

    }
}
