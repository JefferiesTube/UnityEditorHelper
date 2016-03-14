using UnityEngine;
using UnityEditor;

namespace UnityEditorHelper
{
    [CustomPropertyDrawer(typeof (LimitAttribute))]
    public class LimitPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                Debug.LogWarning("LimitAttribute can only be applied on integer properties/fields");
                return;
            }

            LimitAttribute limiter = attribute as LimitAttribute;
            property.intValue = limiter.Limit(EditorGUI.IntField(position, property.name, property.intValue));
        }
    }
}