using UnityEngine;
using UnityEditor;
using System.Collections;
using NodeFramework.Scriptable;

namespace NodeEditor
{
	public class NodeEditorWindow : EditorWindow
	{
		[SerializeField]
		Node m_SelectedNode;

		[MenuItem ("Window/Node Editor")]
		static void Init()
		{
			NodeEditorWindow window = (NodeEditorWindow)EditorWindow.GetWindow (typeof (NodeEditorWindow));
			window.Show();
		}

		GraphAsset m_Graph;

		void OnEnable()
		{

		}

		void OnGUI()
		{
			InputOutputGUI();

			NodesGUI();

			HandleSelectedNode();
		}

		void InputOutputGUI()
		{
			if(m_Graph)
			{
				for (int i = 0; i < m_Graph.nodes.Count; i++)
				{
					InputOutputGUI(m_Graph.nodes[i]);
					OutputsGUI(m_Graph.nodes[i]);
				}
			}
		}

		void InputOutputGUI(Node node)
		{
			if(node)
			{
				foreach(Input input in node.inputs)
				{
					if(input)
					{
						float width =  15f;
						float height = 15f;
						float xPos = node.rect.xMin - width + 1;
						float yPos = node.rect.yMin + input.layoutRect.center.y - height * 0.5f;

						GUI.Box(new Rect(xPos,yPos, width, height),GUIContent.none);
					}
				}
			}
		}

		void OutputsGUI(Node node)
		{
			if(node)
			{
				foreach(Output output in node.outputs)
				{
					if(output)
					{
						float width =  15f;
						float height = 15f;
						float xPos = node.rect.xMax - 1;
						float yPos = node.rect.yMin + output.layoutRect.center.y - height * 0.5f;

						GUI.Box(new Rect(xPos,yPos, width, height),GUIContent.none);
					}
				}
			}
		}

		void NodesGUI()
		{
			if(m_Graph)
			{
				EditorGUIUtility.labelWidth = 75f;

				BeginWindows();

				for (int i = 0; i < m_Graph.nodes.Count; i++)
				{
					Node node = m_Graph.nodes[i];

					if(node)
					{
						node.rect = GUILayout.Window(i, new Rect(node.rect.position, new Vector2(node.rect.width,0f)), DoNodeGUI, node.header);
					}
				}

				EndWindows();
			}
		}

		void DoNodeGUI(int windowId)
		{
			Node node = m_Graph.nodes[windowId];

			UpdateSelectedNode(node);

			if(node)
			{
				NodeEditor nodeEditor = Editor.CreateEditor(node) as NodeEditor;

				nodeEditor.DrawInputsAndOutputs();

				EditorGUILayout.Space();

				nodeEditor.OnInspectorGUI();

				GUI.DragWindow(new Rect(0, 0, 10000, 20));
			}
		}

		void UpdateSelectedNode(Node node)
		{
			EventType type = Event.current.type;

			if(type == EventType.MouseUp && Event.current.button == 0)
			{
				m_SelectedNode = node;

				Repaint();
			}
		}

		void HandleSelectedNode()
		{
			EventType type = Event.current.type;

			if(m_SelectedNode)
			{
				switch(type) {
				case EventType.KeyDown:

					if(Event.current.keyCode == KeyCode.Delete || Event.current.keyCode == KeyCode.Backspace)
					{
						m_Graph.DestroyNode(m_SelectedNode);

						Event.current.Use();
					}

					break;

				default:
					break;
				}
			}
		}

		void CreateNode()
		{
			if(m_Graph)
			{
				Node node = m_Graph.CreateNode();
				node.rect = new Rect(Vector2.zero, Vector2.one * 150f);
			}
		}

		void OnSelectionChange()
		{
			GraphAsset l_graph = Selection.activeObject as GraphAsset;

			if(l_graph && m_Graph != l_graph)
			{
				m_Graph = l_graph;
				Repaint();
			}
		}
	}
}
