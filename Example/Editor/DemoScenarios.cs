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
            new DemoScenarioContent("Horizontal block with named style 'TL LogicBar 1'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Horizontal, "TL LogicBar 1"))
                    {
                        EditorGUILayout.TextField("Text", "");
                        EditorGUILayout.ColorField("Color", Color.grey);
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXFMZLSORUWGYLMFQQCEVCMEBGG6Z3JMNBGC4RAGERCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
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
                        DrawSampleControls();
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXFMZLSORUWGYLMFEUQU6YKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOKRSXQ5CGNFSWYZBIEJKGK6DUEIWCAIRCFE5QUIBAEAQEKZDJORXXER2VJFGGC6LPOV2C4Q3PNRXXERTJMVWGIKBCINXWY33SEIWCAQ3PNRXXELTHOJSXSKJ3BJ6QU===".FromBase32()),
            new DemoScenarioContent("Vertical block with named style 'Box'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Vertical, "Box"))
                    {
                        DrawSampleControls();
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXFMZLSORUWGYLMFQQCEQTPPARCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
            new DemoScenarioContent("Vertical block with named style 'GroupBox'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Vertical, "GroupBox"))
                    {
                        DrawSampleControls();
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXFMZLSORUWGYLMFQQCER3SN52XAQTPPARCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
            new DemoScenarioContent("Vertical block with named style 'TE NodeBox'",
                "Same as above but uses a style of a given name",
                delegate
                {
                    using (new EditorBlock(EditorBlock.Orientation.Vertical, "TE NodeBox"))
                    {
                        DrawSampleControls();
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEE3DPMNVSQRLENF2G64SCNRXWG2ZOJ5ZGSZLOORQXI2LPNYXFMZLSORUWGYLMFQQCEVCMEBGG6Z3JMNBGC4RAGERCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
        }
    };

    public static DemoScenario RoundedBox = new DemoScenario
    {
        Name = "RoundedBox",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("RoundedBox", "A simple solid colored rectangle with rounded corners. Currently, no further customizations are available",
                delegate
                {
                    using (new RoundedBox())
                    {
                        DrawSampleControls();
                    }
                }, "OVZWS3THEAUG4ZLXEBJG65LOMRSWIQTPPAUCSKIKPMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOINXWY33SIZUWK3DEFAREG33MN5ZCELBAINXWY33SFZTXEZLZFE5QU7I=".FromBase32()),
            new DemoScenarioContent("RoundedBox with color", "For the moment this needs 2 SwitchColor blocks. This will be improved in a future release",
                delegate
                {
                    using (new SwitchColor(Color.cyan))
                    {
                        using (new RoundedBox())
                        {
                            using (new SwitchColor(Color.white))
                            {
                                DrawSampleControls();
                            }
                        }
                    }
                }, "OVZWS3THEAUG4ZLXEBJXO2LUMNUEG33MN5ZCQQ3PNRXXELTDPFQW4KJJBJ5QUIBAEAQHK43JNZTSAKDOMV3SAUTPOVXGIZLEIJXXQKBJFEFCAIBAEB5QUIBAEAQCAIBAEB2XG2LOM4QCQ3TFO4QFG53JORRWQQ3PNRXXEKCDN5WG64ROO5UGS5DFFEUQUIBAEAQCAIBAEB5QUIBAEAQCAIBAEAQCAIBAIVSGS5DPOJDVKSKMMF4W65LUFZKGK6DUIZUWK3DEFARFIZLYOQRCYIBCEIUTWCRAEAQCAIBAEAQCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXEG33MN5ZEM2LFNRSCQISDN5WG64RCFQQEG33MN5ZC4Z3SMV4SSOYKEAQCAIBAEAQCA7IKEAQCAID5BJ6Q====".FromBase32()),
        }
    };

    public static DemoScenario EditorFrame = new DemoScenario
    {
        Name = "EditorFrame",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("EditorFrame", "A box with a header looking like an index card",
                delegate
                {
                    using (new EditorFrame("Caption", Color.white))
                    {
                        DrawSampleControls();
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEM4TBNVSSQISDMFYHI2LPNYRCYICDN5WG64ROO5UGS5DFFEUQU6YKEAQCAICFMRUXI33SI5KUSTDBPFXXK5BOKRSXQ5CGNFSWYZBIEJKGK6DUEIWCAIRCFE5QUIBAEAQEKZDJORXXER2VJFGGC6LPOV2C4Q3PNRXXERTJMVWGIKBCINXWY33SEIWCAQ3PNRXXELTHOJSXSKJ3BJ6Q====".FromBase32()),
            new DemoScenarioContent("EditorFrame, colored Caption", "Same as above, but with customized color for the caption",
                delegate
                {
                    using (new EditorFrame("Caption", Color.cyan))
                    {
                        DrawSampleControls();
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEM4TBNVSSQISDMFYHI2LPNYRCYICDN5WG64ROMN4WC3RJFEFHWCRAEAQCARLENF2G64SHKVEUYYLZN52XILSUMV4HIRTJMVWGIKBCKRSXQ5BCFQQCEIRJHMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXEG33MN5ZEM2LFNRSCQISDN5WG64RCFQQEG33MN5ZC4Z3SMV4SSOYKPU======".FromBase32()),
            new DemoScenarioContent("EditorFrame, fixed width", "Same as above, but with a fixed width",
                delegate
                {
                    using (new EditorFrame("Caption", Color.cyan, 500))
                    {
                        DrawSampleControls();
                    }
                }, "OVZWS3THEAUG4ZLXEBCWI2LUN5ZEM4TBNVSSQISDMFYHI2LPNYRCYICDN5WG64ROMN4WC3RMEA2TAMBJFEFHWCRAEAQCARLENF2G64SHKVEUYYLZN52XILSUMV4HIRTJMVWGIKBCKRSXQ5BCFQQCEIRJHMFCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXEG33MN5ZEM2LFNRSCQISDN5WG64RCFQQEG33MN5ZC4Z3SMV4SSOYKPU======".FromBase32()),
        }
    };

    public static DemoScenario FoldableEditorFrame = new DemoScenario
    {
        Name = "FoldableEditorFrame",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("FoldableEditorFrame", "Similar to EditorFrame, but can be collapsed by clicking on the header",
                delegate
                {
                    using (FoldableEditorFrame foldable = new FoldableEditorFrame("[FoldableEditorFrameExample]", "Click me!", Color.white, Color.white))
                    {
                        if(foldable.Expanded)
                        {
                            DrawSampleControls();
                        }
                        else
                            GUILayout.Space(10);
                    }
                }, "OVZWS3THEAUEM33MMRQWE3DFIVSGS5DPOJDHEYLNMUQGM33MMRQWE3DFEA6SA3TFO4QEM33MMRQWE3DFIVSGS5DPOJDHEYLNMUUCEW2GN5WGIYLCNRSUKZDJORXXERTSMFWWKRLYMFWXA3DFLURCYIBCINWGSY3LEBWWKIJCFQQEG33MN5ZC453INF2GKLBAINXWY33SFZ3WQ2LUMUUSSCT3BIQCAIBANFTCQZTPNRSGCYTMMUXEK6DQMFXGIZLEFEFCAIBAEB5QUIBAEAQCAIBAEBCWI2LUN5ZEOVKJJRQXS33VOQXFIZLYORDGSZLMMQUCEVDFPB2CELBAEIRCSOYKEAQCAIBAEAQCARLENF2G64SHKVEUYYLZN52XILSDN5WG64SGNFSWYZBIEJBW63DPOIRCYICDN5WG64ROM5ZGK6JJHMFCAIBAEB6QUIBAEAQGK3DTMUFCAIBAEAQCAIBAI5KUSTDBPFXXK5BOKNYGCY3FFAYTAKJ3BJ6Q====".FromBase32()),
            new DemoScenarioContent("FoldableEditorFrame, colored caption and content", "Same as above, but with customized colors",
                delegate
                {
                    using (FoldableEditorFrame foldable = new FoldableEditorFrame("[FoldableEditorFrameExample]", "Click me!", Color.cyan, Color.red))
                    {
                        if(foldable.Expanded)
                        {
                            DrawSampleControls();
                        }
                        else
                            GUILayout.Space(10);
                    }
                }, "OVZWS3THEAUEM33MMRQWE3DFIVSGS5DPOJDHEYLNMUQGM33MMRQWE3DFEA6SA3TFO4QEM33MMRQWE3DFIVSGS5DPOJDHEYLNMUUCEW2GN5WGIYLCNRSUKZDJORXXERTSMFWWKRLYMFWXA3DFLURCYIBCINWGSY3LEBWWKIJCFQQEG33MN5ZC4Y3ZMFXCYICDN5WG64ROOJSWIKJJBJ5QUIBAEAQGSZRIMZXWYZDBMJWGKLSFPBYGC3TEMVSCSCRAEAQCA6YKEAQCAIBAEAQCARLENF2G64SHKVEUYYLZN52XILSUMV4HIRTJMVWGIKBCKRSXQ5BCFQQCEIRJHMFCAIBAEAQCAIBAIVSGS5DPOJDVKSKMMF4W65LUFZBW63DPOJDGSZLMMQUCEQ3PNRXXEIRMEBBW63DPOIXGO4TFPEUTWCRAEAQCA7IKEAQCAIDFNRZWKCRAEAQCAIBAEAQEOVKJJRQXS33VOQXFG4DBMNSSQMJQFE5Q====".FromBase32()),
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

    private static Vector2 _switchGUIDepthScrollPos;

    public static DemoScenario SwitchGUIDepth = new DemoScenario
    {
        Name = "SwitchGUIDepth",
        Scenarios = new List<DemoScenarioContent>
        {
            new DemoScenarioContent("SwitchGUIDepth", "Similar to EditorFrame, but can be collapsed by clicking on the header",
                delegate
                {
                    Rect rect = EditorGUILayout.GetControlRect(false, 50);

                    GUI.RepeatButton(rect, "Button 2");
                    using (new SwitchGUIDepth(999))
                    {
                        rect.xMin += 40;
                        rect.yMin += 30;
                        rect.xMax -= 40;
                        rect.yMax += 30;
                        GUI.RepeatButton(rect, "Button 1");
                    }
                    GUILayout.Space(40);
                }, "KJSWG5BAOJSWG5BAHUQEKZDJORXXER2VJFGGC6LPOV2C4R3FORBW63TUOJXWYUTFMN2CQZTBNRZWKLBAGUYCSOYKBJDVKSJOKJSXAZLBORBHK5DUN5XCQ4TFMN2CYIBCIJ2XI5DPNYQDEIRJHMFHK43JNZTSAKDOMV3SAU3XNF2GG2CHKVEUIZLQORUCQOJZHEUSSCT3BIQCAIBAOJSWG5BOPBGWS3RAFM6SANBQHMFCAIBAEBZGKY3UFZ4U22LOEAVT2IBTGA5QUIBAEAQHEZLDOQXHQTLBPAQC2PJAGQYDWCRAEAQCA4TFMN2C46KNMF4CAKZ5EAZTAOYKEAQCAICHKVES4UTFOBSWC5CCOV2HI33OFBZGKY3UFQQCEQTVOR2G63RAGERCSOYKPUFEOVKJJRQXS33VOQXFG4DBMNSSQNBQFE5Q====".FromBase32()),
        }
    };

    private static void DrawSampleControls()
    {
        EditorGUILayout.TextField("Text", "");
        EditorGUILayout.ColorField("Color", Color.grey);
    }
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
    public Vector3 ScrollPos;

    public DemoScenarioContent(string caption, string description, Action sample, string sampleCode)
    {
        Caption = caption;
        Description = description;
        Sample = sample;
        SampleCode = sampleCode;
    }
}