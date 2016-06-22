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
		/*
		if(m_Graph)
		{
			if(GUILayout.Button("Create Node"))
			{
				CreateNode();
			}
		}
		*/

		if(m_Graph)
		{
			BeginWindows();

			int windowID = 0;

			foreach(TestNode node in m_Graph.nodes)
			{
				node.rect = GUI.Window(windowID, node.rect, DoWindow, "Node");

				windowID++;
			}

			EndWindows();
		}
	}

	void DoWindow(int windowId)
	{
		
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}

	void CreateNode()
	{
		if(m_Graph)
		{
			TestNode node = m_Graph.CreateTestNode();
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
