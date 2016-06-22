using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(CustomNode))]
public class CustomNodeEditor : Editor
{
	public override void OnInspectorGUI()
	{
		SerializedProperty vectorProperty = serializedObject.FindProperty("m_Vector");

		serializedObject.Update();

		EditorGUILayout.PropertyField(vectorProperty);

		serializedObject.ApplyModifiedProperties();
	}
}
