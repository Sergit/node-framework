﻿using System.Collections.Generic;

namespace NodeFramework.Core
{
	public class Node<TInput,TOutput> : INode<TInput,TOutput>
		where TInput : new()
		where TOutput : new()
	{
		public List<TInput> inputs { get { return m_Inputs; } }
		public List<TOutput> outputs { get { return m_Outputs; } }

		public TInput CreateInput()
		{
			TInput l_input = new TInput();

			inputs.Add(l_input);

			return l_input;
		}

		public TOutput CreateOutput()
		{
			TOutput l_output = new TOutput();

			outputs.Add(l_output);

			return l_output;
		}

		public virtual void OnCreate()
		{

		}

		public void DestroyInput(TInput input)
		{
			if(inputs.Contains(input))
			{
				inputs.Remove(input);
			}
		}

		public void DestroyOutput(TOutput output)
		{
			if(outputs.Contains(output))
			{
				outputs.Remove(output);
			}
		}

		public void Clear()
		{
			inputs.Clear();
			outputs.Clear();
		}

		List<TInput> m_Inputs = new List<TInput>();
		List<TOutput> m_Outputs = new List<TOutput>();
	}
}
