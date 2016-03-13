# UnityEditorHelper
An organized bunch of scripts to make editor scripting in Unity easier - gathered from some of my projects and other free sources 

# Samples

## HighlightBox
A box with round edges that can be colored and used to highlight some components

![Alt Text](https://imgur.com/41b7dYL)
            
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
			
