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
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXEQ33SNF5G63TUMFWCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
            new DemoScenarioContent("Horizontal block with named style 'Box'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Horizontal, "Box"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXEQ33SNF5G63TUMFWCYIBCIJXXQIRJFEFHWCRAEAQCARLENF2G64SHKVEUYYLZN52XILSUMV4HIRTJMVWGIKBCKRSXQ5BCFQQCEIRJHMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXEG33MN5ZEM2LFNRSCQISDN5WG64RCFQQEG33MN5ZC4Z3SMV4SSOYKPU======".FromBase32()),
            new DemoScenarioContent("Horizontal block with named style 'GroupBox'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Horizontal, "GroupBox"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXEQ33SNF5G63TUMFWCYIBCI5ZG65LQIJXXQIRJFEFHWCRAEAQCARLENF2G64SHKVEUYYLZN52XILSUMV4HIRTJMVWGIKBCKRSXQ5BCFQQCEIRJHMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXEG33MN5ZEM2LFNRSCQISDN5WG64RCFQQEG33MN5ZC4Z3SMV4SSOYKPU======".FromBase32()),
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
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXFMZLSORUWGYLMFEUQU6YKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOKRSXQ5CGNFSWYZBIEJKGK6DUEIWCAIRCFE5QUIBAEAQEKZDJORXXER2VJFGGC6LPOV2C4Q3PNRXXERTJMVWGIKBCINXWY33SEIWCAQ3PNRXXELTHOJSXSKJ3BJ6QU===".FromBase32()),
            new DemoScenarioContent("Vertical block with named style 'Box'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Vertical, "Box"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXFMZLSORUWGYLMFQQCEQTPPARCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
            new DemoScenarioContent("Horizontal block with named style 'GroupBox'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Vertical, "GroupBox"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXFMZLSORUWGYLMFQQCER3SN52XAQTPPARCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
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
                }, "OVZWS3THEAUG4ZLXEBJG65LOMRSWIQTPPAUCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
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
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEM4TBNVSSQISDMFYHI2LPNYRCYICDN5WG64ROO5UGS5DFFEUQU6YKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOKRSXQ5CGNFSWYZBIEJKGK6DUEIWCAIRCFE5QUIBAEAQEKZDJORXXER2VJFGGC6LPOV2C4Q3PNRXXERTJMVWGIKBCINXWY33SEIWCAQ3PNRXXELTHOJSXSKJ3BJ6Q====".FromBase32()),
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
                }, "OVZWS3THEAUEM33MMRQWE3DFIVSGS5DPOJDHEYLNMUQGM33MMRQWE3DFEA6SA3TFO4QEM33MMRQWE3DFIVSGS5DPOJDHEYLNMUUCEW2GN5WGIYLCNRSUKZDJORXXERTSMFWWKRLYMFWXA3DFLURCYIBCINWGSY3LEBWWKIJCFQQEG33MN5ZC453INF2GKLBAINXWY33SFZ3WQ2LUMUUSSCT3BIQCAIBANFTCQZTPNRSGCYTMMUXEK6DQMFXGIZLEFEFCAIBAEB5QUIBAEAQCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAIBAEAQCARLENF2G64SHKVEUYYLZN52XILSDN5WG64SGNFSWYZBIEJBW63DPOIRCYICDN5WG64ROM5ZGK6JJHMFCAIBAEB6QUIBAEAQGK3DTMUFCAIBAEAQCAIBAI5KUSTDBPFXXK5BOKNYGCY3FFAYTAKJ3BJ6Q====".FromBase32()),
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
