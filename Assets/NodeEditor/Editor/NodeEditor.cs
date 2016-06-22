using UnityEngine;
using UnityEditor;
using System.Collections;

namespace NodeEditor
{
	[CustomEditor(typeof(Node))]
	public class NodeEditor : Editor
	{
		public override void OnInspectorGUI() {}

		public void DrawInputsAndOutputs()
		{
			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.MinHeight(EditorGUIUtility.singleLineHeight));

			EditorGUILayout.BeginVertical();

			InputsGUI();

			EditorGUILayout.EndVertical();

			GUILayout.FlexibleSpace();

			GUILayout.Space(30f);

			GUILayout.FlexibleSpace();

			EditorGUILayout.BeginVertical();

			OutputsGUI();

			EditorGUILayout.EndVertical();

			EditorGUILayout.EndHorizontal();
		}

		void InputsGUI()
		{
			Node node = target as Node;

			GUILayout.FlexibleSpace();

			foreach(Input input in node.inputs)
			{
				GUILayout.Label(input.name);

				if(Event.current.type == EventType.Repaint)
				{
					input.layoutRect = GUILayoutUtility.GetLastRect();
				}

				GUILayout.FlexibleSpace();
			}

		}

		void OutputsGUI()
		{
			Node node = target as Node;

			GUILayout.FlexibleSpace();

			foreach(Output output in node.outputs)
			{
				EditorGUILayout.BeginHorizontal();

				GUILayout.FlexibleSpace();

				GUILayout.Label(output.name);

				if(Event.current.type == EventType.Repaint)
				{
					output.layoutRect = GUILayoutUtility.GetLastRect();
				}

				EditorGUILayout.EndHorizontal();
			}

			GUILayout.FlexibleSpace();
		}
	}
}
