﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class ScriptableNode<TInput, TOutput> : ScriptableObject, INode<TInput, TOutput>
		where TInput : ScriptableInput
		where TOutput : ScriptableOutput<TInput>
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

		[ContextMenu("Create Input")]
		public TInput CreateInput()
		{
			TInput l_input = default(TInput);

			if(m_Creator != null)
			{
				l_input = creator.CreateInstance<TInput>();

				l_input.name = "Input";

				inputs.Add(l_input);
			}

			return l_input;
		}

		[ContextMenu("Create Output")]
		public TOutput CreateOutput()
		{
			TOutput l_output = default(TOutput);

			if(m_Creator != null)
			{
				l_output = creator.CreateInstance<TOutput>();

				l_output.name = "Output";

				outputs.Add(l_output);
			}

			return l_output;
		}

		public void DestroyInput(TInput input)
		{
			if(creator && inputs.Contains(input))
			{
				inputs.Remove(input);

				creator.DestroyInstance(input);
			}
		}

		public void DestroyOutput(TOutput output)
		{
			if(creator && outputs.Contains(output))
			{
				outputs.Remove(output);

				creator.DestroyInstance(output);
			}
		}

		public void Clear()
		{
			for (int i = 0; i < inputs.Count; i++)
			{
				DestroyInput(inputs[i]);
			}

			for(int i = 0; i < outputs.Count; i++)
			{
				DestroyOutput(outputs[i]);
			}

			inputs.Clear();
			outputs.Clear();
		}

		public virtual void OnCreate()
		{
			
		}

		protected virtual void OnDestroy()
		{
			Clear();	
		}

		[SerializeField][HideInInspector]
		ScriptableInstanceCreator m_Creator;

		[SerializeField][HideInInspector]
		List<TInput> m_Inputs = new List<TInput>();

		[SerializeField][HideInInspector]
		List<TOutput> m_Outputs = new List<TOutput>();
	}
}
