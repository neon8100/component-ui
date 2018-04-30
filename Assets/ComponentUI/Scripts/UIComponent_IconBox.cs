using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIComponent_IconBox : MonoBehaviour {

    [SerializeField]
    Image iconBox;

    [SerializeField]
    TextMeshProUGUI text;

    public void SetText(string s)
    {
        text.text = s;
    }

    public Sprite icon { get { return iconBox.sprite; } set { iconBox.sprite = value; } }


}
