using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorHelper;
using UnityEngine;

public class DemoScriptEditor : EditorWindow
{
    private enum EditorPage { PropertyDrawer, Blocks, Utility, About }

    private EditorPage _currentPage;

    [MenuItem("Tools/UnityEditorHelper/Open Demo Window")]
    public static void OpenDemoEditor()
    {
        GetWindow<DemoScriptEditor>(false, "Demo");
    }

    private DemoObject _demoObject;
    private SerializedObject _serializedObject;

    private static List<DemoScenario> _blockDemoScenarios;

    private void OnEnable()
    {
        _blockDemoScenarios = new List<DemoScenario>
        {
            DemoScenarios.EditorBlockHorizontal,
            DemoScenarios.EditorBlockVertical,
            DemoScenarios.RoundedBox,
            DemoScenarios.EditorFrame,
            DemoScenarios.FoldableEditorFrame,
        };

        _demoObject = CreateInstance<DemoObject>();
        _serializedObject = new SerializedObject(_demoObject);
    }

    private void OnGUI()
    {
        using (new EditorBlock(EditorBlock.Orientation.Vertical))
        {
            DrawToolbar();

            switch (_currentPage)
            {
                case EditorPage.PropertyDrawer:
                    DrawPropertyDrawer();
                    break;

                case EditorPage.Blocks:
                    DrawBlockExamples();
                    break;

                case EditorPage.Utility:
                    using (new PaddedBlock(8, 8, 16, 0))
                        DrawUtilityDemos();
                    break;

                case EditorPage.About:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public void DrawToolbar()
    {
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        string[] enumNames = Enum.GetNames(typeof(EditorPage));
        EditorPage[] enumValues = (EditorPage[])Enum.GetValues(typeof(EditorPage));
        for (int i = 0; i < enumNames.Length; i++)
        {
            if (GUILayout.Toggle(_currentPage == enumValues[i], enumNames[i], EditorStyles.toolbarButton, GUILayout.Width(100)))
            {
                _currentPage = enumValues[i];
            }
        }
        GUILayout.Toolbar(0, new[] { "" }, EditorStyles.toolbar, GUILayout.ExpandWidth(true));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
    }

    private void DrawPropertyDrawer()
    {
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("Layer"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("Tag"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("SortingLayer"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("LimitLow"));
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("LimitBoth"));

        _serializedObject.ApplyModifiedProperties();
    }

    private void DrawUtilityDemos()
    {
        bool expanded = true;
        using (new FoldableBlock(ref expanded, "GetAssetPath"))
        {
            EditorGUILayout.LabelField("", "The Asset \"SampleEditor.cs\" is located at the following path:");
            EditorGUILayout.TextField("", EditorHelper.GetAssetPath("SampleEditor.cs"));
        }

        using (new FoldableBlock(ref expanded, "DrawIconHeader"))
        {
            if (EditorHelper.DrawIconHeader("DemoKey", EditorGUIUtility.FindTexture("SceneAsset Icon"), "Caption (foldable)", Color.white))
            {
                EditorGUILayout.LabelField("", "Some fancy content...");
            }

            if (EditorHelper.DrawIconHeader("DemoKey", EditorGUIUtility.FindTexture("Shader Icon"), "Caption (non-foldable)", Color.white, false))
            {
                EditorGUILayout.LabelField("", "Even more fancy content...");
            }
        }

        using (new FoldableBlock(ref expanded, "GUIDrawRect"))
        {
            using (new EditorBlock(EditorBlock.Orientation.Horizontal))
            {
                for (int i = 0; i <= 10; i++)
                {
                    Rect rect = EditorGUILayout.GetControlRect(false, 32);
                    rect.width = 32;
                    EditorHelper.GUIDrawRect(rect, new Color(0.1f * i, 0.7f, 0.8f));
                }
            }
        }

        using (new FoldableBlock(ref expanded, "DrawTiledTexture"))
        {
            Rect rect = EditorGUILayout.GetControlRect(false, 64);
            EditorHelper.DrawTiledTexture(rect, EditorGUIUtility.FindTexture("_Help"));
        }

        using (new FoldableBlock(ref expanded, "CreateCheckerTex"))
        {
            using (new EditorBlock(EditorBlock.Orientation.Horizontal))
            {
                using (new EditorBlock(EditorBlock.Orientation.Vertical))
                {
                    Rect rect = EditorGUILayout.GetControlRect(false, 32);
                    rect.width = 32;
                    GUI.DrawTexture(rect, EditorHelper.CreateCheckerTex(Color.blue, Color.cyan, 32));

                    rect = EditorGUILayout.GetControlRect(false, 32);
                    rect.width = 32;
                    GUI.DrawTexture(rect, EditorHelper.CreateCheckerTex(Color.blue, Color.cyan, 32, 8));
                }

                using (new EditorBlock(EditorBlock.Orientation.Vertical))
                {
                    Rect rect = EditorGUILayout.GetControlRect(false, 64);
                    rect.width = 64;
                    GUI.DrawTexture(rect, EditorHelper.CreateCheckerTex(new Color(0.1f, 0.1f, 0.1f, 0.5f), new Color(0.2f, 0.2f, 0.2f, 0.5f), 64));

                    rect = EditorGUILayout.GetControlRect(false, 64);
                    rect.width = 64;
                    GUI.DrawTexture(rect, EditorHelper.CreateCheckerTex(new Color(0.1f, 0.1f, 0.1f, 0.5f), new Color(0.2f, 0.2f, 0.2f, 0.5f), 64, 8));
                }

                Rect largeRect = EditorGUILayout.GetControlRect(false, 128);
                largeRect.width = 128;
                GUI.DrawTexture(largeRect, EditorHelper.CreateCheckerTex(new Color(0.1f, 0.1f, 0.1f, 0.5f), new Color(0.2f, 0.2f, 0.2f, 0.5f), 128, 64));
            }
        }

        using (new FoldableBlock(ref expanded, "DrawOutline"))
        {
            EditorGUILayout.Space();
            using (new EditorBlock(EditorBlock.Orientation.Horizontal))
            {
                EditorGUILayout.Space();
                Rect rect = EditorGUILayout.GetControlRect(false, 64);
                rect.width = 128;
                EditorHelper.DrawOutline(rect, Color.blue, 4f);
                EditorHelper.GUIDrawRect(rect, new Color(1f, 1f, 1f, 0.5f));
                EditorGUILayout.Space();

                rect = EditorGUILayout.GetControlRect(false, 64);
                rect.width = 128;
                EditorHelper.DrawOutline(rect, Color.blue, 4f, EditorHelper.OutlineMode.Centered);
                EditorHelper.GUIDrawRect(rect, new Color(1f, 1f, 1f, 0.5f));
                EditorGUILayout.Space();

                rect = EditorGUILayout.GetControlRect(false, 64);
                rect.width = 128;
                EditorHelper.DrawOutline(rect, Color.blue, 4f, EditorHelper.OutlineMode.Inside);
                EditorHelper.GUIDrawRect(rect, new Color(1f, 1f, 1f, 0.5f));
                EditorGUILayout.Space();
            }
            EditorGUILayout.Space();
        }
    }

    private int _selectedBlockIndex = -1;
    private Vector2 _scrollPos;

    private void DrawBlockExamples()
    {
        GUILayout.Space(-10);
        using (new EditorBlock(EditorBlock.Orientation.Horizontal, GUILayout.ExpandWidth(true)))
        {
            using (new EditorBlock(EditorBlock.Orientation.Vertical, "Box", GUILayout.Width(200), GUILayout.ExpandHeight(true)))
            {
                _selectedBlockIndex = GUILayout.SelectionGrid(_selectedBlockIndex, _blockDemoScenarios.Select(s => s.Name).ToArray(), 1);
            }
            using (new EditorBlock(EditorBlock.Orientation.Vertical, GUILayout.ExpandHeight(true)))
            {
                if (_selectedBlockIndex >= 0)
                {
                    using (new ScrollViewBlock(ref _scrollPos, GUILayout.ExpandWidth(true)))
                    {
                        foreach (DemoScenarioContent scenario in _blockDemoScenarios[_selectedBlockIndex].Scenarios)
                        {
                            using (FoldableEditorFrame block = new FoldableEditorFrame("[SampleEditorScenario]." + scenario.Caption, scenario.Caption, Color.white, Color.white))
                            {
                                if (block.Expanded)
                                {
                                    EditorGUILayout.LabelField(scenario.Description, EditorStyles.miniLabel );

                                    EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
                                    string[] tabs = { "Sample", "Code" };
                                    for (int i = 0; i < tabs.Length; i++)
                                    {
                                        if (GUILayout.Toggle(i == (scenario.ShowCode ? 1 : 0), tabs[i], EditorStyles.toolbarButton, GUILayout.Width(100)))
                                        {
                                            scenario.ShowCode = i == 1;
                                        }
                                    }
                                    GUILayout.Toolbar(0, new[] { "" }, EditorStyles.toolbar, GUILayout.ExpandWidth(true));
                                    EditorGUILayout.EndHorizontal();
                                    EditorGUILayout.Space();

                                    GUILayout.Space(-10);
                                    using (new EditorBlock(EditorBlock.Orientation.Vertical, "Box"))
                                    {
                                        using (new PaddedBlock(10))
                                        {
                                            if (scenario.ShowCode)
                                            {
                                                EditorGUILayout.TextArea(scenario.SampleCode, GUILayout.MinHeight(120));
                                            }
                                            else
                                            {
                                                scenario.Sample.Invoke();
                                            }
                                        }
                                    }
                                }
                                else
                                    EditorGUILayout.Space();
                            }
                        }
                    }
                }
            }
        }
    }
}