using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorHelper;
using UnityEngine;

public static class DemoScenarios
{
    public static DemoScenario EditorBlockHorizontal = new DemoScenario
    {
        Name = "EditorBlock (horizontal)",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("Simple horizontal block", "Same as EditorGUILayout.BeginHorizontal/EndHorizontal",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Horizontal))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "Blubb"),
            new DemoScenarioContent("Horizontal block with named style 'Box'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Horizontal, "Box"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "Blubb2"),
            new DemoScenarioContent("Horizontal block with named style 'GroupBox'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Horizontal, "GroupBox"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "Blubb2"),
        }
    };

    public static DemoScenario EditorBlockVertical = new DemoScenario
    {
        Name = "EditorBlock (vertical)",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("Simple vertical block", "Same as EditorGUILayout.BeginVertical/EndVertical",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Vertical))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "Blubb"),
            new DemoScenarioContent("Vertical block with named style 'Box'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Vertical, "Box"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "Blubb2"),
            new DemoScenarioContent("Horizontal block with named style 'GroupBox'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Vertical, "GroupBox"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "Blubb2"),
        }
    };

    public static DemoScenario RoundedBox = new DemoScenario
    {
        Name = "RoundedBox",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("RoundedBox", "Awesome Description",
                delegate
                {
                    using (new RoundedBox())
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "Blubb"),
        }
    };

    public static DemoScenario EditorFrame = new DemoScenario
    {
        Name = "EditorFrame",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("Custom EditorFrame", "Awesome Description",
                delegate
                {
                    using (new EditorFrame("Caption", Color.white))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "Blubb"),
        }
    };

    public static DemoScenario FoldableEditorFrame = new DemoScenario
    {
        Name = "FoldableEditorFrame",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("Custom FoldableEditorFrame", "Awesome Description",
                delegate
                {
                    using (FoldableEditorFrame foldable = new FoldableEditorFrame("[FoldableEditorFrameExample]", "Click me!", Color.white, Color.white))
                    {
                        if(foldable.Expanded)
                        {
                            EditorGUILayout.TextField("Text", "");
                            EditorGUILayout.ColorField("Color", Color.grey);
                        }
                        else
                            GUILayout.Space(10);
                    }
                }, "Blubb"),
        }
    };

    //ToDo
    //SwitchColor
    //SwitchBackgroundColor
    //SwitchGUIDepth
    //IndentBlock
    //ScrollViewBlock
    //PaddedBlock
    //FoldableBlock
}

public class DemoScenario
{
    public string Name;

    public List<DemoScenarioContent> Scenarios;

    public DemoScenario()
    {
        Scenarios = new List<DemoScenarioContent>();
    }
}

public class DemoScenarioContent
{
    public string Caption;
    public string Description;
    public Action Sample;
    public string SampleCode;

    public bool ShowCode;

    public DemoScenarioContent(string caption, string description, Action sample, string sampleCode)
    {
        Caption = caption;
        Description = description;
        Sample = sample;
        SampleCode = sampleCode;
    }
}
