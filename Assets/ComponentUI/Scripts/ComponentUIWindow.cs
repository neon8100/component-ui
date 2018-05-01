using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace ComponentUI.Base
{
    public class ComponentUIWindow : ComponentUICore
    {
        public static bool isActive;

        public delegate void OnPause();
        public OnPause onPauseEvent;

        public delegate void OnUnpause();
        public OnUnpause onUnpauseEvent;

        private UnityEvent m_onOpen;
        private UnityEvent m_onClose;


        public GameObject child;

        public bool doNotIgnoreInput;


        public UnityEvent onOpen
        {
            get
            {
                if (m_onOpen == null)
                {
                    m_onOpen = new UnityEvent();
                }

                return m_onOpen;
            }
        }

        public UnityEvent onClose
        {
            get
            {
                if (m_onClose == null)
                {
                    m_onClose = new UnityEvent();
                }
                return m_onClose;
            }

        }

        public virtual void OnEnable()
        {
            if (Application.isPlaying)
            {
                //Show the open animation;
                GameObject animObj;
                if (child != null)
                {
                    animObj = child;
                }
                else
                {
                    animObj = gameObject;
                }

                animObj.GetComponent<Transform>().localScale = new Vector3(1, 0, 0);
                //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onWindowEnter);
                LeanTween.scale(animObj, new Vector3(1, 1, 1), 0.3f).setIgnoreTimeScale(true).setEaseOutBack();

                if (onPauseEvent != null)
                {
                    onPauseEvent();
                }

            }

            transform.SetAsLastSibling();
        }


        public virtual void Awake()
        {
            if (onOpen != null)
            {
                onOpen.Invoke();
            }
        }


        public override void Update()
        {

            if (onPauseEvent != null)
            {
                onPauseEvent();
            }

            if (!doNotIgnoreInput)
            {
                isActive = true;
            }


            //Closes on Escape;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Close();
            }

            base.Update();

        }

        public virtual void OnDisable()
        {

            if (onUnpauseEvent != null)
            {
                onUnpauseEvent();
            }

            if (!doNotIgnoreInput)
            {
                isActive = false;
            }
        }

        public void OnDestroy()
        {
            if (onUnpauseEvent != null)
            {
                onUnpauseEvent();
            }
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {

            gameObject.SetActive(false);

            isActive = false;

            if (onClose != null)
            {
                onClose.Invoke();
            }
        }

    }
}
