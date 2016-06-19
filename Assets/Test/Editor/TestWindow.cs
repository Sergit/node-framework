using UnityEngine;
using UnityEditor;
using System.Collections;

public class TestWindow : EditorWindow
{
	[MenuItem ("Window/Test Window")]
	static void Init()
	{
		TestWindow window = (TestWindow)EditorWindow.GetWindow (typeof (TestWindow));
		window.Show();
	}

	TestAsset m_Asset;
	TestAsset m_Cache;

	void OnEnable()
	{

	}

	void OnGUI()
	{
		if(m_Asset)
		{
			if(GUILayout.Button("Create Node"))
			{
				TestStorage storage = ScriptableObject.CreateInstance<TestStorage>();
				//storage.hideFlags = HideFlags.HideInHierarchy;
				storage.name = "Node";
				m_Asset.nodes.Add(storage);
				AssetDatabase.AddObjectToAsset(storage,m_Asset);
				EditorUtility.SetDirty(m_Asset);
				AssetDatabase.SaveAssets();
			}



		}
	}

	void OnSelectionChange()
	{
		TestAsset l_Asset = Selection.activeObject as TestAsset;

		if(l_Asset && m_Asset != l_Asset)
		{
			m_Asset = l_Asset;
			Repaint();
		}
	}
}
