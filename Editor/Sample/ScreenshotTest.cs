using UnityEditor;
using UnityEngine;

namespace UnityEditorHelper
{
    [CustomEditor(typeof (SampleScript))]
    public class ScreenshotTest : Editor
    {
        public Vector2 _scrollPos;
        private bool state;

        public override void OnInspectorGUI()
        {
            using (new FoldableBlock(ref state, "Foldable Block"))
            {
                if(state)
                {
                    EditorGUILayout.Slider("Range property", 5, 0, 10);
                    EditorGUILayout.TextField("Sample Field", GUILayout.Height(150));
                    EditorGUILayout.ObjectField("Object Field", null, typeof (Transform), true);
                }
            }
        }
    }
}