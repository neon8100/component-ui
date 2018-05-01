using UnityEngine;
using UnityEditor;

namespace ComponentUI.EditorTools
{
    public class UIComponent_MenuItems : Editor
    {

        [MenuItem("GameObject/UI/ComponentUI/Button", false, 0)]
        static void SpawnButton()
        {
            InitPrefab("Button");
        }

        [MenuItem("GameObject/UI/ComponentUI/Icon Box", false, 0)]
        static void SpawnIconBox()
        {
            InitPrefab("Icon Box");
        }

        [MenuItem("GameObject/UI/ComponentUI/Panel", false, 0)]
        static void SpawnPanel()
        {
            InitPrefab("Panel");
        }

        [MenuItem("GameObject/UI/ComponentUI/Window", false, 0)]
        static void SpawnWindow()
        {
            InitPrefab("Window");
        }

        [MenuItem("GameObject/UI/ComponentUI/Progress Bar", false, 0)]
        static void SpawnProgressBar()
        {
            InitPrefab("Progress Bar");
        }

        [MenuItem("GameObject/UI/ComponentUI/Tab Area", false, 0)]
        static void SpawnTabArea()
        {
            InitPrefab("Tabs");
        }

        [MenuItem("GameObject/UI/ComponentUI/Header and Body", false, 0)]
        static void SpawnHeaderAndBody()
        {
            InitPrefab("Header and Body");
        }

        [MenuItem("GameObject/UI/ComponentUI/Text/Title Value", false, 0)]
        static void SpawnTitleValue()
        {
            InitPrefab("Title Value Text");
        }

        [MenuItem("GameObject/UI/ComponentUI/Menu List Item", false, 0)]
        static void SpawnMenuListItem()
        {
            InitPrefab("Menu List Item");
        }

        [MenuItem("GameObject/UI/ComponentUI/Scroll View", false, 0)]
        static void ScrollView()
        {
            InitPrefab("Scroll View");
        }

        static GameObject clickedObject;

        private static GameObject InitPrefab(string objectName, bool editor = true)
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(objectName));
            go.name = objectName;
            if (editor)
            {
                clickedObject = UnityEditor.Selection.activeObject as GameObject;
                if (clickedObject != null)
                {
                    go.transform.SetParent(clickedObject.transform, false);
                }
            }
            return go;
        }
    }
}

