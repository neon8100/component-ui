using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    public class ComponentUI_Tabs : ComponentUICore
    {

        public GameObject[] tabs;
        public GameObject tabInFocus;
        public int selectedIndex;

        public override void Start()
        {

            for (int i = 0; i < tabs.Length; i++)
            {
                GameObject tabButton = tabs[i];
                int count = i;
                tabButton.GetComponent<Button>().onClick.AddListener(() => { selectedIndex = count; tabInFocus = tabs[count]; SkinObject(); });

                EventTrigger e = tabButton.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener((eventData) => { OnEnter(); });
                e.triggers.Add(entry);
            }
        }

        void SwitchTab(GameObject tabButton)
        {
            Button button = tabButton.GetComponent<Button>();
            //tabButton.GetComponent<HorizontalLayoutGroup>().padding = new RectOffset(0, 0, 0, 0);
            button.colors = skinData.tabActiveColors;
            tabInFocus = tabButton;



            foreach (Transform child in button.targetGraphic.transform)
            {
                if (child.GetComponent<Text>())
                {
                    child.GetComponent<Text>().color = skinData.tabActiveTextcolor;
                }
                else if (child.GetComponent<TMPro.TextMeshProUGUI>())
                {
                    child.GetComponent<TMPro.TextMeshProUGUI>().color = skinData.tabActiveTextcolor;
                }

                if (child.GetComponent<Image>())
                {
                    child.GetComponent<Image>().color = skinData.tabActiveTextcolor;
                }
            }

            //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseDownTab);

        }
        void ResetTab(GameObject tabButton)
        {
            Button button = tabButton.GetComponent<Button>();

            button.colors = skinData.tabInactiveColors;

            foreach (Transform child in button.targetGraphic.transform)
            {
                //Supports normal text or text mesh pro text
                if (child.GetComponent<Text>())
                {
                    child.GetComponent<Text>().color = skinData.tabInactiveTextColor;
                }
                else if (child.GetComponent<TMPro.TextMeshProUGUI>())
                {
                    child.GetComponent<TMPro.TextMeshProUGUI>().color = skinData.tabInactiveTextColor;
                }

                if (child.GetComponent<Image>())
                {
                    child.GetComponent<Image>().color = skinData.tabInactiveTextColor;
                }
            }

        }
        public override void SkinObject()
        {
            foreach (GameObject tabButton in tabs)
            {

                Button button = tabButton.GetComponent<Button>();





                //Get the text  or any components in children;
                //not actually sure what this is doing...
                if (button.targetGraphic.GetComponentsInChildren<Text>() != null)
                {
                    Text[] texts = button.targetGraphic.GetComponentsInChildren<Text>();
                }
                if (button.targetGraphic.GetComponentsInChildren<Image>() != null)
                {
                    Image[] images = button.targetGraphic.GetComponentsInChildren<Image>();
                }


                if (Application.isEditor)
                {
                    if (tabInFocus != null && tabInFocus == tabButton)
                    {
                        SwitchTab(tabButton);
                    }
                    else
                    {
                        ResetTab(tabButton);
                    }
                }
                else
                {
                    if (EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject == tabButton || tabInFocus == tabButton)
                    {

                        SwitchTab(tabButton);
                    }
                    else
                    {
                        ResetTab(tabButton);
                    }
                }
            }
        }

        public void OnEnter()
        {
            //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onMouseEnterTab);
        }
    }
}
