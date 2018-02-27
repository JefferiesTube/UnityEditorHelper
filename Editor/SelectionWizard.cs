using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace UnityEditorHelper
{
    public abstract class SelectionWizard<T> : ScriptableWizard
    {
        public static SelectionWizard<T> Instance;

        private void OnEnable()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            Instance = null;
        }

        private Vector2 _scrollPos = Vector2.zero;
        private string _searchString = "";
        protected List<T> Elements;
        protected float ItemSize;
        protected float Padding;
        protected Func<T, string, bool> SearchStringFilterFunc { get; set; }
        private float _clickTime;
        protected T Selected;
        protected Func<T, Texture2D> TextureGetter;
        protected Func<T, string> CaptionGetter;
        protected Action<T> SelectionCallback;


        private static Texture2D _selectionTexture;
        protected static Texture2D selectionTexture { get { return _selectionTexture ?? CreateSelectionTexture(); } }

        const float textHeight = 26;


        private static Texture2D CreateSelectionTexture()
        {
            Texture2D tex = new Texture2D(2, 2, TextureFormat.ARGB32, false)
            {
                name = "[EditorHelper] Selection Texture",
                hideFlags = HideFlags.DontSave
            };

            tex.SetPixels(new[] { Color.blue, Color.blue, Color.blue, Color.blue });
            tex.filterMode = FilterMode.Point;
            tex.Apply();
            _selectionTexture = tex;
            return tex;
        }

        public static void Show<K>(string caption, List<T> elements, Func<T, string, bool> searchStringFilterFunc, Func<T, Texture2D> textureGetter,
            Func<T, string> captionGetter, Action<T> selectionCallback, float itemSize = 80, float padding = 10) where K : SelectionWizard<T>
        {
            if (Instance != null)
            {
                Instance.Close();
                Instance = null;
            }

            SelectionWizard<T> self = DisplayWizard<K>(caption);
            self.Elements = elements;
            self.SearchStringFilterFunc = searchStringFilterFunc;
            self.ItemSize = itemSize;
            self.Padding = padding;
            self.TextureGetter = textureGetter;
            self.CaptionGetter = captionGetter;
            self.SelectionCallback = selectionCallback;
        }

        private void OnGUI()
        {
            EditorGUIUtility.labelWidth = 80;
            bool close = false;
            using (new EditorBlock(EditorBlock.Orientation.Horizontal))
            {
                GUILayout.Space(84f);
                _searchString = EditorGUILayout.TextField("", _searchString, "SearchTextField");

                if (GUILayout.Button("", "SearchCancelButton", GUILayout.Width(18f)))
                {
                    _searchString = "";
                    GUIUtility.keyboardControl = 0;
                }
                GUILayout.Space(84);
            }

            List<T> elements = Elements.Where(arg => SearchStringFilterFunc.Invoke(arg, _searchString)).ToList();

            float padded = ItemSize + Padding;
            int columns = Math.Max(1, Mathf.FloorToInt(Screen.width / padded));
            int offset = 0;
            Rect rect = new Rect(10, 0, ItemSize, ItemSize);
            GUILayout.Space(10f);
            using (new ScrollViewBlock(ref _scrollPos))
            {
                int rows = 1;

                while (offset < elements.Count)
                {
                    using (new EditorBlock(EditorBlock.Orientation.Horizontal))
                    {
                        int col = 0;
                        rect.x = 10;

                        for (; offset < elements.Count; ++offset)
                        {
                            Rect frame = new Rect(rect);
                            frame.xMin -= 2;
                            frame.yMin -= 2;
                            frame.xMax += 2;
                            frame.yMax += 8 + textHeight;

                            if (Selected != null && ReferenceEquals(Selected, elements[offset]))
                            {
                                GUI.DrawTexture(frame, selectionTexture, ScaleMode.StretchToFill);
                            }

                            if (GUI.Button(rect, ""))
                            {
                                if (Event.current.button == 0)
                                {
                                    float delta = Time.realtimeSinceStartup - _clickTime;
                                    _clickTime = Time.realtimeSinceStartup;

                                    if (!ReferenceEquals(Selected, elements[offset]))
                                    {
                                        Selected = elements[offset];
                                        Repaint();
                                    }
                                    else if (delta < 0.5f)
                                        close = true;
                                }
                            }

                            if (Event.current.type == EventType.Repaint)
                            {
                                GUI.DrawTexture(rect, EditorHelper.Checkerboard, ScaleMode.ScaleToFit);
                                GUI.DrawTexture(rect, TextureGetter.Invoke(elements[offset]), ScaleMode.ScaleAndCrop);
                            }

                            GUI.backgroundColor = new Color(1f, 1f, 1f, 0.5f);
                            GUI.contentColor = new Color(1f, 1f, 1f, 0.7f);
                            GUI.Label(new Rect(rect.x, rect.y + rect.height, rect.width, 32f), CaptionGetter.Invoke(elements[offset]), "ProgressBarBack");
                            GUI.contentColor = Color.white;
                            GUI.backgroundColor = Color.white;

                            if (++col >= columns)
                            {
                                ++offset;
                                break;
                            }
                            rect.x += padded;
                        }
                    }
                    GUILayout.Space(padded);
                    rect.y += padded + textHeight;
                    ++rows;
                }
                GUILayout.Space(rows * textHeight);
            }
            if (close)
            {
                if (SelectionCallback != null)
                    SelectionCallback.Invoke(Selected);
                Close();
            }
        }
    }
}