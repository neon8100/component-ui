using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIComponent_PanelBox : UIComponent {

    public Image header;
    public Image footer;
    public bool hasTabs;
    public UIComponent_Tabs[] tabs;
    public bool hasFooter;
    public bool footerIsTabs;

    public bool footerColorOverride;

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public override void SkinObject()
    {
        base.SkinObject();

        if (header != null)
        {
            header.sprite = skinData.headerImage;
            header.color = skinData.headerColor;
        }
        if (body != null)
        {
            body.sprite = hasFooter ? skinData.bodyImage : skinData.footerImage;
            body.color = skinData.bodyColor;
        }
        if (footer != null)
        {
            footer.sprite = skinData.footerImage;
            if (!footerColorOverride)
            {
                footer.color = footerIsTabs ? skinData.spaceColor : skinData.footerColor;
            }
        }

        }
    }
