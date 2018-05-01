using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    [RequireComponent(typeof(InputField))]
    [ExecuteInEditMode]
    public class ComponentUI_InputField : ComponentUICore
    {

        InputField m_input;

        void Awake()
        {
            m_input = GetComponent<InputField>();

        }

        public override void SkinObject()
        {
            body.sprite = skinData.inputSkin;
            body.color = skinData.inputSkinColor;
            m_input.selectionColor = skinData.inputSelectionColor;
            m_input.textComponent.color = skinData.inputTextColor;
            m_input.caretColor = skinData.inputCaretColor;
        }


        public InputField inputField
        {
            get
            {
                return m_input;
            }
        }

    }
}
