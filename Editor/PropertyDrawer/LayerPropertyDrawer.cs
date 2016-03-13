using UnityEngine;
using UnityEditor;

namespace UnityEditorHelper
{
    [CustomPropertyDrawer(typeof (LayerAttribute))]
    public class LayerPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.intValue = EditorGUI.LayerField(position, property.name, property.intValue);
        }
    }
}