using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityEditorHelper
{
    public static class EditorHelper
    {
        private static GUIStyle _simpleRectStyle;

        public static GUIStyle SimpleRectStyle
        {
            get
            {
                if (_simpleRectStyle != null)
                    return _simpleRectStyle;

                Texture2D simpleTexture = new Texture2D(1, 1);
                simpleTexture.SetPixel(0, 0, Color.white);
                simpleTexture.Apply();
                return _simpleRectStyle = new GUIStyle { normal = { background = simpleTexture } };
            }
        }

        private static Texture2D _checkerboard;

        public static Texture2D Checkerboard
        {
            get
            {
                return _checkerboard ?? (_checkerboard = CreateCheckerTex(
                           new Color(0.1f, 0.1f, 0.1f, 0.5f),
                           new Color(0.2f, 0.2f, 0.2f, 0.5f)));
            }
        }

        #region Utility Functions

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

        public static GUIStyle GetColoredTextStyle(Color color, FontStyle fontStyle)
        {
            return new GUIStyle
            {
                normal = { textColor = color },
                fontStyle = fontStyle
            };
        }

        public static int IndexOf(this SerializedProperty prop, string value)
        {
            if (!prop.isArray)
                return -1;
            for (int i = 0; i < prop.arraySize; i++)
            {
                if (prop.GetArrayElementAtIndex(i).stringValue.Equals(value))
                    return i;
            }
            return -1;
        }

        #endregion Utility Functions

        #region GUI Utilities

        public static bool DrawIconHeader(string key, Texture icon, string caption, Color captionColor, bool canToggle = true)
        {
            bool state = EditorPrefs.GetBool(key, true);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField(new GUIContent(icon), EditorStyles.miniLabel, GUILayout.Width(22), GUILayout.Height(22));
                using (new SwitchBackgroundColor(captionColor))
                {
                    EditorGUILayout.BeginVertical();
                    GUILayout.Space(5);
                    GUIStyle style = new GUIStyle { normal = { textColor = captionColor }, fontStyle = FontStyle.Bold };
                    EditorGUILayout.LabelField(caption, style);
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.Space();
                string cap = state ? "\u25bc" : "\u25b2";
                if (canToggle)
                {
                    if (GUILayout.Button(cap, EditorStyles.label, GUILayout.Width(16), GUILayout.Height(16)))
                    {
                        state = !state;
                        EditorPrefs.SetBool(key, state);
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(2);
            return state;
        }

        public static void GUIDrawRect(Rect position, Color color)
        {
            using (new SwitchColor(color))
            {
                GUI.Box(position, GUIContent.none, SimpleRectStyle);
            }
        }

        public static void DrawTiledTexture(Rect rect, Texture tex)
        {
            GUI.BeginGroup(rect);
            {
                int width = Mathf.RoundToInt(rect.width);
                int height = Mathf.RoundToInt(rect.height);

                for (int y = 0; y < height; y += tex.height)
                {
                    for (int x = 0; x < width; x += tex.width)
                    {
                        GUI.DrawTexture(new Rect(x, y, tex.width, tex.height), tex);
                    }
                }
            }
            GUI.EndGroup();
        }

        public static Texture2D CreateCheckerTex(Color c0, Color c1, int size = 16, int columns = 2)
        {
            if (columns > size)
                throw new ArgumentOutOfRangeException("Cannot generate Checkerboard texture with more columns than texture has pixels");
            if (size % columns != 0)
                throw new ArgumentOutOfRangeException("Size has to be dividable by columns");

            Texture2D tex = new Texture2D(size, size)
            {
                name = "[EditorHelper] Checker Texture",
                hideFlags = HideFlags.DontSave
            };

            int fieldSize = size / columns;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (y / fieldSize % 2 != 0)
                        tex.SetPixel(x, y, y / fieldSize % 2 == 0 || x / fieldSize % 2 == 0 ? c1 : c0);
                    else
                        tex.SetPixel(x, y, y / fieldSize % 2 != 0 || x / fieldSize % 2 != 0 ? c1 : c0);
                }
            }
            tex.Apply();
            tex.filterMode = FilterMode.Point;
            return tex;
        }

        public enum OutlineMode { Outside, Centered, Inside }

        public static void DrawOutline(Rect rect, Color color, float borderWidth = 1f, OutlineMode mode = OutlineMode.Outside)
        {
            if (Event.current.type == EventType.Repaint)
            {
                Texture2D tex = EditorGUIUtility.whiteTexture;
                GUI.color = color;

                switch (mode)
                {
                    case OutlineMode.Outside:
                        GUI.DrawTexture(new Rect(rect.xMin - borderWidth, rect.yMin - borderWidth, borderWidth, rect.height + borderWidth * 2), tex); // left
                        GUI.DrawTexture(new Rect(rect.xMax, rect.yMin - borderWidth, borderWidth, rect.height + borderWidth * 2), tex); // right
                        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin - borderWidth, rect.width, borderWidth), tex); // top
                        GUI.DrawTexture(new Rect(rect.xMin, rect.yMax, rect.width + borderWidth, borderWidth), tex); // bottom
                        break;

                    case OutlineMode.Centered:
                        GUI.DrawTexture(new Rect(rect.xMin - borderWidth / 2, rect.yMin - borderWidth / 2, borderWidth, rect.height + borderWidth), tex); // left
                        GUI.DrawTexture(new Rect(rect.xMax - borderWidth / 2, rect.yMin - borderWidth / 2, borderWidth, rect.height + borderWidth), tex); // right
                        GUI.DrawTexture(new Rect(rect.xMin - borderWidth / 2, rect.yMin - borderWidth / 2, rect.width + borderWidth, borderWidth), tex); // top
                        GUI.DrawTexture(new Rect(rect.xMin - borderWidth / 2, rect.yMax - borderWidth / 2, rect.width + borderWidth, borderWidth), tex); // bottom
                        break;

                    case OutlineMode.Inside:
                        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, borderWidth, rect.height), tex); // left
                        GUI.DrawTexture(new Rect(rect.xMax - borderWidth, rect.yMin, borderWidth, rect.height), tex); // right
                        GUI.DrawTexture(new Rect(rect.xMin, rect.yMin, rect.width, borderWidth), tex); // top
                        GUI.DrawTexture(new Rect(rect.xMin, rect.yMax - borderWidth, rect.width, borderWidth), tex); // bottom
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("mode", mode, null);
                }

                GUI.color = Color.white;
            }
        }

        #endregion GUI Utilities
    }

    #region Blocks

    public sealed class RoundedBox : IDisposable
    {
        public RoundedBox()
        {
            GUILayout.Space(8f);
            GUILayout.BeginHorizontal();
            GUILayout.Space(4f);
            EditorGUILayout.BeginHorizontal(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).GetStyle("sv_iconselector_labelselection"), GUILayout.MinHeight(10f));
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

    public sealed class EditorFrame : IDisposable
    {
        public EditorFrame(string caption, Color captionColor, int width = -1)
        {
            if (width == -1)
                GUILayout.BeginVertical();
            else
                GUILayout.BeginVertical(GUILayout.Width(width));

            GUILayout.Space(8);
            using (new EditorBlock(EditorBlock.Orientation.Horizontal))
            {
                GUILayout.Space(11);
                using (new EditorBlock(EditorBlock.Orientation.Horizontal, "TL LogicBar 1"))
                {
                    GUILayout.Space(4);
                    EditorGUILayout.LabelField(caption, EditorHelper.GetColoredTextStyle(captionColor, FontStyle.Bold));
                }
                GUILayout.FlexibleSpace();
                GUILayout.Space(11);
            }
            GUILayout.Space(-11);

            EditorGUILayout.BeginVertical("GroupBox");
        }

        public void Dispose()
        {
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndVertical();
        }
    }

    public sealed class FoldableEditorFrame : IDisposable
    {
        public bool Expanded;

        public FoldableEditorFrame(string key, string caption, Color captionColor, Color folderColor, int width = -1)
        {
            Expanded = EditorPrefs.GetBool(key, true);
            Draw(ref Expanded, caption, captionColor, folderColor, width);
            EditorPrefs.SetBool(key, Expanded);
        }

        public FoldableEditorFrame(ref bool expanded, string caption, Color captionColor, Color folderColor, int width = -1)
        {
            Draw(ref expanded, caption, captionColor, folderColor, width);
        }

        private void Draw(ref bool expanded, string caption, Color captionColor, Color folderColor, int width = -1)
        {
            Expanded = expanded;

            if (width == -1)
                GUILayout.BeginVertical();
            else
                GUILayout.BeginVertical(GUILayout.Width(width));
            GUILayout.Space(8);

            using (new EditorBlock(EditorBlock.Orientation.Horizontal))
            {
                GUIStyle coloredTextStyle = EditorHelper.GetColoredTextStyle(captionColor, FontStyle.Bold);
                float textWidth = coloredTextStyle.CalcSize(new GUIContent(caption)).x + 15;

                GUILayout.Space(11);
                expanded = EditorGUILayout.Toggle(expanded, "TL LogicBar 0", GUILayout.Width(Mathf.Max(textWidth, 196)), GUILayout.Height(24));
                GUILayout.Space(-Mathf.Max(textWidth, 196) + 4);
                using (new EditorBlock(EditorBlock.Orientation.Vertical))
                {
                    GUILayout.Space(6);
                    EditorGUILayout.LabelField(caption, coloredTextStyle);
                }
            }
            GUILayout.Space(-11);
            if (Expanded)
            {
                using (new SwitchColor(folderColor))
                {
                    EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
                }
            }
        }

        public void Dispose()
        {
            EditorGUILayout.EndVertical();
            if (Expanded)
            {
                EditorGUILayout.EndVertical();
            }
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

        public EditorBlock(Orientation orientation, string style) : this(orientation, style, new GUILayoutOption[] { })
        {
        }

        public EditorBlock(Orientation orientation) : this(orientation, null, new GUILayoutOption[] { })
        {
        }

        public EditorBlock(Orientation orientation, params GUILayoutOption[] layoutOptions) : this(orientation, null, layoutOptions)
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
            _savedColor = GUI.color;
            GUI.color = newColor;
        }

        public void Dispose()
        {
            GUI.color = _savedColor;
        }
    }

    public sealed class SwitchBackgroundColor : IDisposable
    {
        private readonly Color _savedColor;

        public SwitchBackgroundColor(Color newColor)
        {
            _savedColor = GUI.backgroundColor;
            GUI.backgroundColor = newColor;
        }

        public void Dispose()
        {
            GUI.backgroundColor = _savedColor;
        }
    }

    public sealed class SwitchGUIDepth : IDisposable
    {
        private readonly int _savedDepth;

        public SwitchGUIDepth(int depth)
        {
            _savedDepth = GUI.depth;
            GUI.depth = depth;
        }

        public void Dispose()
        {
            GUI.depth = _savedDepth;
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

    public class PaddedBlock : IDisposable
    {
        public PaddedBlock(int left, int right, int top, int bottom)
        {
            GUIStyle style = new GUIStyle(EditorStyles.inspectorDefaultMargins) { padding = new RectOffset(left, right, top, bottom) };
            EditorGUILayout.BeginVertical(style);
        }

        public PaddedBlock(int padding) : this(padding, padding, padding, padding)
        {
        }

        public void Dispose()
        {
            EditorGUILayout.EndVertical();
        }
    }

    public sealed class FoldableBlock : IDisposable
    {
        private readonly Color _defaultBackgroundColor;

        private readonly bool _expanded;

        public FoldableBlock(ref bool expanded, string header) : this(ref expanded, header, null)
        {
        }

        public FoldableBlock(ref bool expanded, string header, Texture2D icon)
        {
            _defaultBackgroundColor = GUI.backgroundColor;
            EditorGUILayout.BeginHorizontal();
            GUI.changed = false;
            if (!GUILayout.Toggle(true, new GUIContent("<b><size=11>" + header + "</size></b>", icon), "dragtab", GUILayout.MinWidth(20f)))
                expanded = !expanded;
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(-2f);

            if (expanded)
            {
                GUILayout.BeginHorizontal();
                EditorGUILayout.BeginHorizontal("TextArea", GUILayout.MinHeight(10f));
                GUILayout.BeginVertical();
            }
            _expanded = expanded;
        }

        public void Dispose()
        {
            if (_expanded)
            {
                GUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
                GUILayout.EndHorizontal();
                GUI.backgroundColor = _defaultBackgroundColor;
            }
        }
    }

    #endregion Blocks
}