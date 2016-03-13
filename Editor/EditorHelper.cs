using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityEditorHelper
{
    public static class EditorHelper
    {
        private static readonly GUIStyle SimpleRectStyle;

        static EditorHelper()
        {
            Texture2D simpleTexture = new Texture2D(1, 1);
            simpleTexture.SetPixel(0, 0, Color.white);
            simpleTexture.Apply();

            SimpleRectStyle = new GUIStyle {normal = {background = simpleTexture}};
        }

        public static bool DrawIconHeader(string key, Texture icon, string caption, Color captionColor)
        {
            bool state = EditorPrefs.GetBool(key, true);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField(new GUIContent(icon), EditorStyles.miniLabel, GUILayout.Width(22), GUILayout.Height(22));
                using (new SwitchColor(captionColor))
                {
                    EditorGUILayout.BeginVertical();
                    GUILayout.Space(5);
                    EditorGUILayout.LabelField(caption, EditorStyles.boldLabel);
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.Space();
                string cap = state ? "\u25bc" : "\u25b2";
                if (GUILayout.Button(cap, EditorStyles.label, GUILayout.Width(16), GUILayout.Height(16)))
                {
                    state = !state;
                    EditorPrefs.SetBool(key, state);
                }
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(2);
            return state;
        }

        public static string GetAssetPath(string assetFileName)
        {
            if (!AssetDatabase.GetAllAssetPaths().Any(p => p.EndsWith(assetFileName)))
            {
                AssetDatabase.Refresh();
            }
            string basePath = AssetDatabase.GetAllAssetPaths().First(p => p.EndsWith(assetFileName));
            int lastDelimiter = basePath.LastIndexOf('/') + 1;
            basePath = basePath.Remove(lastDelimiter, basePath.Length - lastDelimiter);
            return basePath;
        }

        public static GUIStyle GetEditorStyle(string style)
        {
            return EditorGUIUtility.GetBuiltinSkin(EditorGUIUtility.isProSkin ? EditorSkin.Scene : EditorSkin.Inspector).GetStyle(style);
        }

        public static void GUIDrawRect(Rect position, Color color)
        {
            using (new SwitchColor(color))
            {
                GUI.Box(position, GUIContent.none, SimpleRectStyle);
            }
        }
    }

    public sealed class HighlightBox : IDisposable
    {
        public HighlightBox() : this(new Color(0.1f, 0.1f, 0.2f)) { }

        public HighlightBox(Color color)
        {
            GUILayout.Space(8f);
            GUILayout.BeginHorizontal();
            GUILayout.Space(4f);
            using (new SwitchColor(color))
            {
                EditorGUILayout.BeginHorizontal(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).GetStyle("sv_iconselector_labelselection"), GUILayout.MinHeight(10f));
            }
            GUILayout.BeginVertical();
            GUILayout.Space(4f);
        }

        public void Dispose()
        {
            GUILayout.Space(3f);
            GUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(3f);
            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
        }
    }

    public sealed class EditorBlock : IDisposable
    {
        public enum Orientation
        {
            Horizontal,
            Vertical
        }

        private readonly Orientation _orientation;

        public EditorBlock(Orientation orientation, string style, params GUILayoutOption[] options)
        {
            _orientation = orientation;
            if (orientation == Orientation.Horizontal)
            {
                EditorGUILayout.BeginHorizontal(string.IsNullOrEmpty(style) ? GUIStyle.none : style, options);
            }
            else
            {
                EditorGUILayout.BeginVertical(string.IsNullOrEmpty(style) ? GUIStyle.none : style, options);
            }
        }

        public EditorBlock(Orientation orientation, string style) : this(orientation, style, new GUILayoutOption[] {})
        {
        }

        public EditorBlock(Orientation orientation) : this(orientation, null, new GUILayoutOption[] {})
        {
        }

        public void Dispose()
        {
            if (_orientation == Orientation.Horizontal)
            {
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                EditorGUILayout.EndVertical();
            }
        }
    }

    public sealed class SwitchColor : IDisposable
    {
        private readonly Color _savedColor;

        public SwitchColor(Color newColor)
        {
            _savedColor = GUI.backgroundColor;
            GUI.color = newColor;
        }

        public void Dispose()
        {
            GUI.color = _savedColor;
        }
    }

    public class IndentBlock : IDisposable
    {
        public IndentBlock()
        {
            EditorGUI.indentLevel++;
        }

        public void Dispose()
        {
            EditorGUI.indentLevel--;
        }
    }

    public class ScrollViewBlock : IDisposable
    {
        public ScrollViewBlock(ref Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, options);
        }

        public void Dispose()
        {
            EditorGUILayout.EndScrollView();
        }
    }

    public sealed class FoldableBlock : IDisposable
    {
        private readonly Color _defaultBackgroundColor;

        private bool _expanded;

        public FoldableBlock(ref bool expanded, string header) : this(ref expanded, header, null)
        {
        }

        public FoldableBlock(ref bool expanded, string header, Texture2D icon)
        {
            _defaultBackgroundColor = GUI.backgroundColor;
            GUILayout.Space(3f);
            GUILayout.BeginHorizontal();
            GUILayout.Space(3f);
            GUI.changed = false;
            if (!GUILayout.Toggle(true, new GUIContent("<b><size=11>" + header + "</size></b>", icon), "dragtab", GUILayout.MinWidth(20f)))
                expanded = !expanded;
            GUILayout.Space(2f);
            GUILayout.EndHorizontal();
            if (!expanded)
            {
                GUILayout.Space(3f);
            }
            else
            {
                GroupStart();
            }
            _expanded = expanded;
        }

        private void GroupStart()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(4f);
            EditorGUILayout.BeginHorizontal("AS TextArea", GUILayout.MinHeight(10f));
            GUILayout.BeginVertical();
            GUILayout.Space(2f);
        }

        private void GroupEnd()
        {
            GUILayout.Space(3f);
            GUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(3f);
            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
            GUI.backgroundColor = _defaultBackgroundColor;
        }

        public void Dispose()
        {
            if(_expanded)
                GroupEnd();
        }
    }
}
