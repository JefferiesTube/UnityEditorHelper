using UnityEditorHelper;
using UnityEngine;

public class DemoObject : ScriptableObject
{
    [Layer]
    public int Layer;

    [Tag]
    public string Tag;

    [SortingLayer]
    public int SortingLayer;

    [Limit(0)]
    public int LimitLow;

    [Limit(-10, 42)]
    public int LimitBoth;
}

