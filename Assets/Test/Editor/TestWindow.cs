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
			EditorGUIUtility.labelWidth = 50f;

			BeginWindows();

			for (int i = 0; i < m_Graph.nodes.Count; i++)
			{
				TestNode node = m_Graph.nodes[i];

				if(node)
				{
					node.rect = new Rect(node.rect.position, new Vector2(node.rect.width, 0f));

					Rect rect = GUILayout.Window(i, node.rect, DrawNode, "Node");

					rect.size = new Vector2(node.rect.width, rect.height);

					node.rect = rect;
				}
			}

			EndWindows();
		}
	}

	void DrawNode(int windowId)
	{
		TestNode node = m_Graph.nodes[windowId];

		if(node)
		{
			Editor editor = Editor.CreateEditor(node);
			editor.OnInspectorGUI();
		}

		GUI.DragWindow(new Rect(0, 0, 10000, 20));
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
