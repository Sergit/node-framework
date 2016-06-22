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
				float headerHeight = 15f;
				float nodeHeight = node.rect.height - headerHeight;
				int numInputs = node.inputs.Count;
				float width =  10f;
				float height = 10f;
				float step = nodeHeight / (float)numInputs;
				float xPos = node.rect.xMin - width + 1;
				float yPos = node.rect.yMin + headerHeight + (step - height) * 0.5f;

				for (int j = 0; j < numInputs; j++)
				{
					ScriptableInput input = node.inputs[j];

					if(input)
					{
						Rect rect = new Rect(xPos,yPos, width, height);

						GUI.Box(rect,GUIContent.none);

						yPos += step;
					}
				}
			}
		}

		void OutputsGUI(Node node)
		{
			if(node)
			{
				float headerHeight = 15f;
				float nodeHeight = node.rect.height - headerHeight;
				int numOutputs = node.outputs.Count;
				float width =  10f;
				float height = 10f;
				float step = nodeHeight / (float)numOutputs;
				float xPos = node.rect.xMax - 1;
				float yPos = node.rect.yMin + headerHeight + (step - height) * 0.5f;

				for (int j = 0; j < numOutputs; j++)
				{
					Output output = node.outputs[j];

					if(output)
					{
						Rect rect = new Rect(xPos,yPos, width, height);

						GUI.Box(rect,GUIContent.none);

						yPos += step;
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
						node.rect = GUILayout.Window(i, node.rect, DoNodeGUI, node.header);
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
				Editor editor = Editor.CreateEditor(node);

				editor.OnInspectorGUI();

				GUI.DragWindow(new Rect(0, 0, 10000, 20));
			}
		}

		void UpdateSelectedNode(Node node)
		{
			EventType type = Event.current.type;

			if(type == EventType.MouseUp && Event.current.button == 0)
			{
				m_SelectedNode = node;
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
