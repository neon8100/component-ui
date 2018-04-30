using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class UIComponent : MonoBehaviour {

	//A complete scriptable object that handles all of the skin data. 
	//Changing this from the default will allow UIComponents to be re-skinned dynamically.
    protected UIComponentSkinData skinData;

    //[SerializeField]
    protected Image body;

    public bool overrideSkin;

    public virtual void Awake() {
        //Defaults the skin data;
       /* if (skinData == null)
        {
            skinData = Resources.Load<UIComponentSkinData>("UI/Data/DefaultUIComponentSkin");
        }
        */

    }

    public virtual void Start()
    {
        if (!overrideSkin)
        {
            SkinObject();
        }
    }


    // Update is called once per frame

    public virtual void Update () {

    }


    /// <summary>
    /// Override and implement this to custom skin the elements of another UIComponent by the references in <see cref="skinData"/>property.
    /// </summary>
    public virtual void SkinObject()
    {
        /*
        if (body != null && skinData!=null)
        {
            body.sprite = skinData.baseImage;
            body.color = skinData.baseColor;
        }*/

    }

}
