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

		Input m_SelectedInput;
		Output m_SelectedOutput;
		Input m_HoveredInput;
		Output m_HoveredOutput;

		int m_LastNearestControl = -1;

		[MenuItem ("Window/Node Editor")]
		static void Init()
		{
			NodeEditorWindow window = (NodeEditorWindow)EditorWindow.GetWindow (typeof (NodeEditorWindow));
			window.Show();
		}

		GraphAsset m_Graph;

		Node GetNode(Output output)
		{
			foreach(Node node in m_Graph.nodes)
			{
				if(node.outputs.Contains(output))
				{
					return node;
				}
			}

			return null;
		}

		Rect GetRect(Node node, Input input)
		{
			float width =  15f;
			float height = 15f;
			float xPos = node.rect.xMin - width + 1;
			float yPos = node.rect.yMin + input.layoutRect.center.y - height * 0.5f;

			return new Rect(xPos,yPos, width, height);
		}

		Rect GetRect(Node node, Output output)
		{
			float width =  15f;
			float height = 15f;
			float xPos = node.rect.xMax - 1;
			float yPos = node.rect.yMin + output.layoutRect.center.y - height * 0.5f;

			return new Rect(xPos,yPos, width, height);
		}

		void OnEnable()
		{

		}

		void OnGUI()
		{
			wantsMouseMove = true;

			DrawConnections();

			InputOutputGUI();

			NodesGUI();

			HandleSelectedNode();

			if(GUIUtility.hotControl == 0 && HandleUtility.nearestControl != m_LastNearestControl)
			{
				m_LastNearestControl = HandleUtility.nearestControl;
				Repaint();
			}

			if(m_Graph)
			{
				EditorUtility.SetDirty(m_Graph);
			}
		}

		void DrawConnections()
		{
			if(m_Graph)
			{
				for (int i = 0; i < m_Graph.nodes.Count; i++)
				{
					DrawConnections(m_Graph.nodes[i]);
				}
			}
		}

		void DrawConnections(Node node)
		{
			if(node)
			{
				foreach(Output output in node.outputs)
				{
					if(output)
					{
						foreach(Input input in output.inputs)
						{
							if(input)
							{
								Node targetNode = GetNode(input);

								if(targetNode)
								{
									Handles.color = Color.white;
									Handles.DrawLine(GetRect(node,output).center,GetRect(targetNode,input).center);
								}
							}
						}
					}
				}
			}
		}

		void InputOutputGUI()
		{
			if(m_Graph)
			{
				for (int i = 0; i < m_Graph.nodes.Count; i++)
				{
					InputOutputGUI(m_Graph.nodes[i]);
				}
			}
		}

		Node GetNode(Input input)
		{
			foreach(Node node in m_Graph.nodes)
			{
				if(node.inputs.Contains(input))
				{
					return node;
				}
			}

			return null;
		}

		void InputOutputGUI(Node node)
		{
			if(node)
			{
				foreach(Input input in node.inputs)
				{
					if(input)
					{
						int controlID = GUIUtility.GetControlID("Input".GetHashCode(),FocusType.Passive);

						Rect rect = GetRect(node,input);

						switch(Event.current.GetTypeForControl(controlID)) {
						case EventType.MouseDown:

							if(Event.current.button == 0 &&
							   GUIUtility.hotControl == 0 &&
							   HandleUtility.nearestControl == controlID)
							{
								GUIUtility.hotControl = controlID;

								m_SelectedInput = input;

								Event.current.Use();
							}

							break;
						
						case EventType.MouseUp:

							if(Event.current.button == 0 &&
							   GUIUtility.hotControl == controlID)
							{
								GUIUtility.hotControl = 0;

								AddConnection(m_HoveredOutput,input);

								m_SelectedInput = null;

								Event.current.Use();
							}

							break;
						    
						case EventType.MouseDrag:

							if(Event.current.button == 0 &&
								GUIUtility.hotControl == controlID)
							{
								Event.current.Use();
							}

							break;

						case EventType.Layout:

							HandleUtility.AddControl(controlID, HandleUtility.DistanceToRectangle(new Vector3(rect.xMin, rect.yMax, 0f),Quaternion.identity,rect.width));

							if(HandleUtility.nearestControl == controlID)
							{
								m_HoveredInput = input;
							}

							break;

						case EventType.Repaint:

							if(GUIUtility.hotControl == controlID)
							{
								Handles.DrawLine(rect.center,Event.current.mousePosition);

								GUI.color = Color.yellow;
							}

							if((GUIUtility.hotControl == 0  || m_SelectedOutput) && 
							   HandleUtility.nearestControl == controlID)
							{
								GUI.color = Color.yellow;
							}

							break;
						}

						GUI.Box(rect,GUIContent.none);

						GUI.color = Color.white;
					}
				}

				foreach(Output output in node.outputs)
				{
					if(output)
					{
						int controlID = GUIUtility.GetControlID("Output".GetHashCode(),FocusType.Passive);

						Rect rect = GetRect(node,output);

						switch(Event.current.GetTypeForControl(controlID)) {
						case EventType.MouseDown:

							if(Event.current.button == 0 &&
								GUIUtility.hotControl == 0 &&
								HandleUtility.nearestControl == controlID)
							{
								GUIUtility.hotControl = controlID;

								m_SelectedOutput = output;

								Event.current.Use();
							}

							break;

						case EventType.MouseUp:

							if(Event.current.button == 0 &&
								GUIUtility.hotControl == controlID)
							{
								GUIUtility.hotControl = 0;

								AddConnection(output,m_HoveredInput);

								m_SelectedOutput = null;

								Event.current.Use();
							}

							break;

						case EventType.MouseDrag:

							if(Event.current.button == 0 &&
								GUIUtility.hotControl == controlID)
							{
								Event.current.Use();
							}

							break;

						case EventType.Layout:

							HandleUtility.AddControl(controlID, HandleUtility.DistanceToRectangle(new Vector3(rect.xMin, rect.yMax, 0f),Quaternion.identity,rect.width));

							if(HandleUtility.nearestControl == controlID)
							{
								m_HoveredOutput = output;
							}
								
							break;

						case EventType.Repaint:
							
							if(GUIUtility.hotControl == controlID)
							{
								Handles.DrawLine(rect.center,Event.current.mousePosition);

								GUI.color = Color.yellow;
							}

							if((GUIUtility.hotControl == 0 || m_SelectedInput)&& 
							   HandleUtility.nearestControl == controlID)
							{
								GUI.color = Color.yellow;
							}

							break;
						}

						GUI.Box(rect,GUIContent.none);
						GUI.color = Color.white;
					}
				}

				if(HandleUtility.nearestControl == 0)
				{
					m_HoveredInput = null;
					m_HoveredOutput = null;
				}
			}
		}

		void AddConnection(Output output, Input input)
		{
			if(output && input)
			{
				output.AddInput(input);
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
			if(Event.current.type == EventType.MouseUp && Event.current.button == 0)
			{
				m_SelectedNode = node;

				Repaint();
			}
		}

		void HandleSelectedNode()
		{
			if(m_SelectedNode)
			{
				switch(Event.current.type) {
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
				m_Graph.CreateNode();
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
