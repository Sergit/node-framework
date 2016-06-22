using UnityEngine;
using UnityEditor;
using System.Collections;

namespace NodeEditor
{
	[CustomEditor(typeof(CustomNode))]
	public class CustomNodeEditor : NodeEditor
	{
		public override void OnInspectorGUI()
		{
			//DrawDefaultInspector();

			EditorGUIUtility.fieldWidth = 100f;

			SerializedProperty vectorProperty = serializedObject.FindProperty("m_Vector");

			serializedObject.Update();

			EditorGUILayout.PropertyField(vectorProperty);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
