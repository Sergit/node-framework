using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class CustomNode : Node
{
	protected override string GetHeader()
	{
		return "Custom Node";
	}

	public override void OnCreate()
	{
		CreateInput();
		CreateInput();
		CreateOutput();
	}

	[SerializeField]
	Vector3 m_Vector;
}
