using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace UnityEditorHelper
{
    [CustomPropertyDrawer(typeof(LayerAttribute))]
    public class LayerPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                Debug.LogWarning("LayerAttribute can only be applied on integer properties/fields");
                return;
            }

            property.intValue = EditorGUI.LayerField(position, property.name, property.intValue);
        }
    }

    [CustomPropertyDrawer(typeof(LimitAttribute))]
    public class LimitPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                Debug.LogWarning("LimitAttribute can only be applied on integer properties/fields");
                return;
            }

            LimitAttribute limiter = (LimitAttribute)attribute;
            property.intValue = limiter.Limit(EditorGUI.IntField(position, property.name, property.intValue));
        }
    }

    [CustomPropertyDrawer(typeof(SortingLayerAttribute))]
    public class SortingLayerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                Debug.LogWarning("SortingLayerAttributes can only be applied on integer properties/fields");
                return;
            }
            EditorGUI.LabelField(position, label);

            position.x += EditorGUIUtility.labelWidth;
            position.width -= EditorGUIUtility.labelWidth;

            string[] sortingLayerNames = GetSortingLayerNames();
            int[] sortingLayerIDs = GetSortingLayerIDs();

            int sortingLayerIndex = Mathf.Max(0, System.Array.IndexOf(sortingLayerIDs, property.intValue));
            sortingLayerIndex = EditorGUI.Popup(position, sortingLayerIndex, sortingLayerNames);
            property.intValue = sortingLayerIDs[sortingLayerIndex];
        }

        private string[] GetSortingLayerNames()
        {
            System.Type internalEditorUtilityType = typeof(InternalEditorUtility);
            PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
            return (string[])sortingLayersProperty.GetValue(null, new object[0]);
        }

        private int[] GetSortingLayerIDs()
        {
            System.Type internalEditorUtilityType = typeof(InternalEditorUtility);
            PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerUniqueIDs", BindingFlags.Static | BindingFlags.NonPublic);
            return (int[])sortingLayersProperty.GetValue(null, new object[0]);
        }
    }

    [CustomPropertyDrawer(typeof(TagAttribute))]
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