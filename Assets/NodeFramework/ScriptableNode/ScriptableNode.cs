using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class ScriptableNode<TInput, TOutput> : ScriptableObject, INode<TInput, TOutput>
		where TInput : ScriptableInput
		where TOutput : ScriptableOutput
	{
		public List<TInput> inputs { get { return m_Inputs; } }
		public List<TOutput> outputs { get { return m_Outputs; } }

		public virtual TInput CreateInput()
		{
			TInput l_input = ScriptableObject.CreateInstance<TInput>();

			inputs.Add(l_input);

			return l_input;
		}

		public virtual TOutput CreateOutput()
		{
			TOutput l_output = ScriptableObject.CreateInstance<TOutput>();

			outputs.Add(l_output);

			return l_output;
		}

		[SerializeField]
		List<TInput> m_Inputs = new List<TInput>();

		[SerializeField]
		List<TOutput> m_Outputs = new List<TOutput>();
	}
}
