using UnityEngine;
using System;
using System.Collections;
using NodeFramework.Scriptable;

[Serializable]
public class CustomNode : Node
{
	protected override string GetHeader()
	{
		return "Custom Node";
	}

	public override void OnCreate()
	{
		input = CreateInput();
		output = CreateOutput();
	}

	[SerializeField]
	ScriptableInput input;

	[SerializeField]
	ScriptableOutput output;

	[SerializeField]
	Vector3 m_Vector;
}
