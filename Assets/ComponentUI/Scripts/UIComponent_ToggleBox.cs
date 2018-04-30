using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComponent_ToggleBox : UIComponent {

    public Toggle toggle {  get { return GetComponent<Toggle>(); } }

	[SerializeField]
	Image handle;

	public override void SkinObject ()
	{
		body.sprite = skinData.toggleBoxSkin;
		body.color = skinData.toggleBoxSkinColor;
		handle.sprite = skinData.toggleBoxToggleSkin;
		handle.color = skinData.toggleBoxToggleColor;
		GetComponent<Toggle> ().colors = skinData.toggleBoxButtonColors;
	}

}
