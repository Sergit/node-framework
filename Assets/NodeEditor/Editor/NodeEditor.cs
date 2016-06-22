using UnityEngine;
using UnityEditor;
using System.Collections;

namespace NodeEditor
{
	[CustomEditor(typeof(Node))]
	public class NodeEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.BeginVertical(GUILayout.Width(100f),GUILayout.Height(25));

			EditorGUILayout.Space();

			EditorGUILayout.EndVertical();
		}
	}
}
