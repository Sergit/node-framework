using UnityEngine;
using System;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable][CreateAssetMenu]
	public class ScriptableNodeStorage : ScriptableObject, INodeStorage<ScriptableInput,ScriptableOutput>
	{
		public List<ScriptableInput> inputs { get { return m_Inputs; }  set { m_Inputs = value; } }

		public List<ScriptableOutput> outputs { get { return m_Outputs; }  set { m_Outputs = value; } }

		[SerializeField]
		List<ScriptableInput> m_Inputs = new List<ScriptableInput>();

		[SerializeField]
		List<ScriptableOutput> m_Outputs = new List<ScriptableOutput>();
	}
}
