using UnityEditor;
using ComponentUI.Base;

namespace ComponentUI.EditorTools.CustomEditors
{
    [CustomEditor(typeof(ComponentUI_Button))]
    public class ComponentUI_ButtonEditor : Editor
    {

        ComponentUI_Button instance;

        public override void OnInspectorGUI()
        {
            instance = (ComponentUI_Button)target;

            instance.SkinObject();

            DrawDefaultInspector();
        }
    }
}
