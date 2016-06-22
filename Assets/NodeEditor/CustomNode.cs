using UnityEngine;
using System;
using System.Collections;
using NodeFramework.Scriptable;

namespace NodeEditor
{
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

			input.name = "Input value";
			output.name = "Output value";
		}
			
		[SerializeField][HideInInspector]
		Input input;

		[SerializeField][HideInInspector]
		Output output;

		[SerializeField]
		Vector3 m_Vector;
	}
}
