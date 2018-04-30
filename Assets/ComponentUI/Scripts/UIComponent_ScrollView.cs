using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIComponent_ScrollView : UIComponent {

	//This is just required to make sure the other bits can be referenced;
	ScrollRect scrollRectComponent;

	Image horizontalBack;
	Image horizontalHandle;

	Image verticalBack;
	Image verticalHandle;


	void Awake(){
		scrollRectComponent = GetComponent<ScrollRect> ();

		horizontalBack = scrollRectComponent.horizontalScrollbar.GetComponent<Image> ();
		horizontalHandle = scrollRectComponent.horizontalScrollbar.GetComponent<Scrollbar> ().targetGraphic.GetComponent<Image> ();

		verticalBack = scrollRectComponent.verticalScrollbar.GetComponent<Image> ();
		verticalHandle = scrollRectComponent.verticalScrollbar.GetComponent<Scrollbar> ().targetGraphic.GetComponent<Image> ();
	}

	public override void SkinObject ()
	{
		horizontalBack.sprite = skinData.scrollSkinSprite;
		verticalBack.sprite = skinData.scrollSkinSprite;

		horizontalBack.color = skinData.scrollSkinColor;
		verticalBack.color = skinData.scrollSkinColor;

		horizontalHandle.sprite = skinData.scrollHandleSprite;
		verticalHandle.sprite = skinData.scrollHandleSprite;

		horizontalHandle.color = skinData.scrollHandleColor;
		verticalHandle.color = skinData.scrollHandleColor;

	}
}
