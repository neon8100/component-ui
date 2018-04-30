using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIComponent_IconProgressBox : UIComponent {

    [SerializeField]
    Image iconBox;

    public Image icon;

    [SerializeField]
    UIComponent_ProgressBar progressBar;

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

    public UIComponent_ProgressBar bar { get { return progressBar; } }

}