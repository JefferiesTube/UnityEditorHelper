using UnityEngine;
using UnityEditor;

namespace UnityEditorHelper
{
    [CustomPropertyDrawer(typeof (TagAttribute))]
    public class TagPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.stringValue = EditorGUI.TagField(position, property.name, property.stringValue);
        }
    }
}