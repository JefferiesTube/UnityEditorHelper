# UnityEditorHelper
An organized bunch of scripts to make editor scripting in Unity easier - gathered from some of my projects and other free sources 

## Samples

### HighlightBox
A box with round edges that can be colored and used to highlight some components

![Imgur](http://i.imgur.com/41b7dYL.png)
            
```csharp
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
```

### EditorBlock
A wrapper for vertical and horizontal oriented blocks that also accepts and additional style.

![Imgur](http://i.imgur.com/NhPueAu.png)
            
```csharp
  using (new EditorBlock(EditorBlock.Orientation.Vertical, "Box"))
  {
      EditorGUILayout.Slider("Range property", 5, 0, 10);
      EditorGUILayout.TextField("Sample Field", GUILayout.Height(150));
      EditorGUILayout.ObjectField("Object Field", null, typeof(Transform), true);
  }
```

### SwitchColor
A wrapper to change the GUIColor automatically without manually caching it and switching it back

![Imgur](http://i.imgur.com/VEBDzBi.png)
            
```csharp
  using (new SwitchColor(Color.cyan))
  {
      EditorGUILayout.Slider("Range property", 5, 0, 10);
  }

  using (new SwitchColor(Color.green))
  {
      EditorGUILayout.TextField("Sample Field", GUILayout.Height(150));
  }

  EditorGUILayout.ObjectField("Object Field", null, typeof(Transform), true);
```

### IndentBlock
A wrapper to indent controls

![Imgur](http://i.imgur.com/Zf17FFg.png)
            
```csharp
  using (new IndentBlock())
  {
  	EditorGUILayout.Slider("Range property", 5, 0, 10);
  	using (new IndentBlock())
  	{
  		EditorGUILayout.TextField("Sample Field", GUILayout.Height(150));
  		EditorGUILayout.ObjectField("Object Field", null, typeof (Transform), true);
  	}
  }
```

### FoldableBlock
A simple foldable block with a header. Can have an optional icon.

![Imgur](http://i.imgur.com/cyuogg2.png)
            
```csharp
  using (new FoldableBlock(ref state, "Foldable Block"))
  {
  	if(state)
  	{
  		EditorGUILayout.Slider("Range property", 5, 0, 10);
  		EditorGUILayout.TextField("Sample Field", GUILayout.Height(150));
  		EditorGUILayout.ObjectField("Object Field", null, typeof (Transform), true);
  	}
  }
```
