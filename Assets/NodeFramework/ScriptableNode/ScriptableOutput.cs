using UnityEngine;
using System;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class ScriptableOutput<TInput> : ScriptableObject, IOutput<TInput> where TInput : ScriptableInput
	{
		public List<TInput> inputs { get { return m_Inputs; } }

		public void AddInput(TInput input)
		{
			if(!inputs.Contains(input))
			{
				inputs.Add(input);
			}
		}

		[SerializeField]
		List<TInput> m_Inputs = new List<TInput>();
	}
}
