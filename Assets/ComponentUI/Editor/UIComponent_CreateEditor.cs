using UnityEngine;
using UnityEditor;

public class UIComponent_CreateEditor : Editor { 
   
    [MenuItem("GameObject/UI/FlexibleUI/Button", false, 0)]
    static void SpawnButton()
    {
        InitPrefab("Button");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Icon Box", false, 0)]
    static void SpawnIconBox()
    {
        InitPrefab("Icon Box");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Panel", false, 0)]
    static void SpawnPanel()
    {
        InitPrefab("Panel");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Window", false, 0)]
    static void SpawnWindow()
    {
        InitPrefab("Window");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Progress Bar", false, 0)]
    static void SpawnProgressBar()
    {
        InitPrefab("Progress Bar");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Tab Area", false, 0)]
    static void SpawnTabArea()
    {
        InitPrefab("Tabs");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Header and Body", false, 0)]
    static void SpawnHeaderAndBody()
    {
        InitPrefab("Header and Body");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Text/Title Value", false, 0)]
    static void SpawnTitleValue()
    {
        InitPrefab("Title Value Text");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Menu List Item", false, 0)]
    static void SpawnMenuListItem()
    {
        InitPrefab("Menu List Item");
    }

    [MenuItem("GameObject/UI/FlexibleUI/Scroll View", false, 0)]
    static void ScrollView()
    {
        InitPrefab("Scroll View");
    }

    /*
    [MenuItem("GameObject/UI/Custom Component System/Drowpdown", false, 0)]
    static void SpawnDropdown()
    {
        InitPrefab("Dropdown");
    }

    

 

    [MenuItem("GameObject/UI/Custom Component System/Input Field", false, 0)]
    static void SpawnInputField()
    {
        InitPrefab("Input Field");
    }

    [MenuItem("GameObject/UI/Custom Component System/Menu Element", false, 0)]
    static void SpawnMenuElement()
    {
        InitPrefab("Menu Element");
    }

    [MenuItem("GameObject/UI/Custom Component System/Navbar Button", false, 0)]
    static void SpawnNavbarButton()
    {
        InitPrefab("Navbar Button");
    }

    [MenuItem("GameObject/UI/Custom Component System/Navbar", false, 0)]
    static void SpawnNavbar()
    {
        InitPrefab("Navigation Bar");
    }

    

   

    [MenuItem("GameObject/UI/Custom Component System/Radial Action Group Button", false, 0)]
    static void SpawnRadialActionGroupButton()
    {
      InitPrefab("Radial Action Button");
    }

    public static GameObject AddRadialActionGroupButton()
    {
        return InitPrefab("Radial Action Button", false);
    }


    [MenuItem("GameObject/UI/Custom Component System/Radial Group", false, 0)]
    static void SpawnRadialGroup()
    {
        InitPrefab("Radial Group");
    }




    [MenuItem("GameObject/UI/Custom Component System/Slider", false, 0)]
    static void SpawnSlider()
    {
        InitPrefab("Slider");
    }

    [MenuItem("GameObject/UI/Custom Component System/Toggle Box", false, 0)]
    static void SpawnToggleBox()
    {
        InitPrefab("Toggle Box");
    }

    [MenuItem("GameObject/UI/Custom Component System/Tab Area", false, 0)]
    static void SpawnTabs()
    {
        InitPrefab("Tabs");
    }
    */

    static GameObject clickedObject;

    private static GameObject InitPrefab(string objectName, bool editor = true)
    {
        GameObject go = Instantiate(Resources.Load<GameObject>(objectName));
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

