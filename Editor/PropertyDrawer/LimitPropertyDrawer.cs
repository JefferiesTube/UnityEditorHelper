using UnityEngine;
using UnityEditor;

namespace UnityEditorHelper
{
    [CustomPropertyDrawer(typeof (LimitAttribute))]
    public class LimitPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LimitAttribute limiter = attribute as LimitAttribute;
            property.intValue = limiter.Limit(EditorGUI.IntField(position, property.name, property.intValue));
        }
    }
}