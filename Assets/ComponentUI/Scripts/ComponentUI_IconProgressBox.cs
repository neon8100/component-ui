using UnityEngine;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    [ExecuteInEditMode]
    public class ComponentUI_IconProgressBox : ComponentUICore
    {

        [SerializeField]
        Image iconBox;

        public Image icon;

        [SerializeField]
        ComponentUI_ProgressBar progressBar;

        [SerializeField]
        bool skinIcon = true;

        [SerializeField]
        Color customIconColor;

        void Awake()
        {
            icon = iconBox.transform.GetChild(0).GetComponent<Image>();
        }

        public override void SkinObject()
        {

            iconBox.color = skinData.progressBarIconBackground;
            if (skinIcon)
            {
                icon.color = skinData.progressBarIcon;
            }
            else
            {
                icon.color = customIconColor;
            }
            body.color = skinData.progressBarBackground;


        }

        public ComponentUI_ProgressBar bar { get { return progressBar; } }

    }
}