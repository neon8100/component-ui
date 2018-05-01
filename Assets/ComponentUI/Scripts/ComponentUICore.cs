using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace ComponentUI.Base
{
    public class ComponentUICore : MonoBehaviour
    {

        //A complete scriptable object that handles all of the skin data. 
        //Changing this from the default will allow UIComponents to be re-skinned dynamically.
        protected ComponentUISkinData skinData;
        
        //The default body image for this component
        protected Image body;

        //determines if parts of the default skinning should be overriden by the inspector
        //this should be handled bespokely by each individual component
        public bool overrideSkin;

        public virtual void Awake()
        {

        }

        public virtual void Start()
        {
            if (!overrideSkin)
            {
                SkinObject();
            }
        }


        // Update is called once per frame
        public virtual void Update()
        {

        }


        /// <summary>
        /// Override and implement this to custom skin the elements of another UIComponent by the references in <see cref="skinData"/>property.
        /// </summary>
        public virtual void SkinObject()
        {
          
        }

    }
}
