using UnityEngine;
using System;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class ScriptableStorage<TInput,TOutput> : ScriptableObject, IStorage<TInput,TOutput> where TInput : ScriptableInput where TOutput : ScriptableOutput
	{
		public List<TInput> inputs { get { return m_Inputs; }  set { m_Inputs = value; } }

		public List<TOutput> outputs { get { return m_Outputs; }  set { m_Outputs = value; } }

		[SerializeField]
		List<TInput> m_Inputs = new List<TInput>();

		[SerializeField]
		List<TOutput> m_Outputs = new List<TOutput>();
	}
}
