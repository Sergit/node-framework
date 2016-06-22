using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(CustomNode))]
public class CustomNodeEditor : Editor
{
	SerializedProperty m_VectorProperty;

	void OnEnable()
	{
		m_VectorProperty = serializedObject.FindProperty("m_Vector");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(m_VectorProperty);

		serializedObject.ApplyModifiedProperties();
	}
}
