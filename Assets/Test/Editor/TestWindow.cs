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

	TestGraphAsset m_Graph;

	void OnEnable()
	{

	}

	void OnGUI()
	{
		if(m_Graph)
		{
			if(GUILayout.Button("Create Node"))
			{
				CreateNode();
			}
		}
	}

	void CreateNode()
	{
		if(m_Graph)
		{
			TestNodeAsset node = m_Graph.CreateNode() as TestNodeAsset;
			node.rect = new Rect(Vector2.zero, Vector2.one * 150f);
		}
	}

	void OnSelectionChange()
	{
		TestGraphAsset l_graph = Selection.activeObject as TestGraphAsset;

		if(l_graph && m_Graph != l_graph)
		{
			m_Graph = l_graph;
			Repaint();
		}
	}
}
