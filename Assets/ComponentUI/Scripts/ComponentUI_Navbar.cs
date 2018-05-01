using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    public class ComponentUI_Navbar : ComponentUICore
    {

        [SerializeField]
        public Button[] buttons;

        public override void SkinObject()
        {

            //Positions the first and last element with the right kind of skin.
            if (transform.childCount > 1)
            {
                transform.GetChild(0).GetComponent<Image>().sprite = skinData.navbarLeft;
                transform.GetChild(0).GetComponent<Image>().type = Image.Type.Sliced;

                for (int i = 1; i < transform.childCount - 1; i++)
                {
                    transform.GetChild(i).GetComponent<Image>().sprite = null;
                }

                transform.GetChild(transform.childCount - 1).GetComponent<Image>().sprite = skinData.navbarRight;
                transform.GetChild(transform.childCount - 1).GetComponent<Image>().type = Image.Type.Sliced;
            }
            else if (transform.childCount == 1)
            {
                transform.GetChild(0).GetComponent<Image>().sprite = skinData.navbarBody;
                transform.GetChild(0).GetComponent<Image>().type = Image.Type.Sliced;
            }

        }
    }
}
