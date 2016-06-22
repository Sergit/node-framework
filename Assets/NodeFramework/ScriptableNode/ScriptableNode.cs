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

		public ScriptableInstanceCreator creator {
			get {
				return m_Creator;
			}
			set {
				m_Creator = value;
			}
		}

		[ContextMenu("CreateInput")]
		public TInput CreateInput()
		{
			TInput l_input = default(TInput);

			if(m_Creator != null)
			{
				l_input = creator.CreateInstance<TInput>();

				inputs.Add(l_input);
			}

			return l_input;
		}

		[ContextMenu("CreateOutput")]
		public TOutput CreateOutput()
		{
			TOutput l_output = default(TOutput);

			if(m_Creator != null)
			{
				l_output = creator.CreateInstance<TOutput>();

				outputs.Add(l_output);
			}

			return l_output;
		}

		[SerializeField][HideInInspector]
		ScriptableInstanceCreator m_Creator;

		[SerializeField]
		List<TInput> m_Inputs = new List<TInput>();

		[SerializeField]
		List<TOutput> m_Outputs = new List<TOutput>();
	}
}
