using UnityEditor;
using UnityEngine;

namespace UnityEditorHelper
{
    [CustomEditor(typeof (SampleScript))]
    public class ScreenshotTest : Editor
    {
        public override void OnInspectorGUI()
        {
            using (new HighlightBox())
            {
                EditorGUILayout.Slider("Range property", 5, 0, 10);
                EditorGUILayout.TextField("Sample Field",  GUILayout.Height(150));
                EditorGUILayout.ObjectField("Object Field", null, typeof (Transform), true);
            }

            using (new HighlightBox(Color.red))
            {
                EditorGUILayout.Slider("Range property", 5, 0, 10);
                EditorGUILayout.TextField("Sample Field", GUILayout.Height(150));
                EditorGUILayout.ObjectField("Object Field", null, typeof(Transform), true);
            }
        }
    }
}