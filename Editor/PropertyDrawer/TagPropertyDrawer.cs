using UnityEngine;
using UnityEditor;

namespace UnityEditorHelper
{
    [CustomPropertyDrawer(typeof (TagAttribute))]
    public class TagPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogWarning("TagAttribute can only be applied on string properties/fields");
                return;
            }

            property.stringValue = EditorGUI.TagField(position, property.name, property.stringValue);
        }
    }
}