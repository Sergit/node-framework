using UnityEngine;
using System;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable][CreateAssetMenu]
	public class ScriptableOutput : ScriptableObject, IOutput<ScriptableValue, ScriptableInput>
	{
		public ScriptableValue value { get { return m_Value; } set { m_Value = value; } }

		public List<ScriptableInput> inputs { get { return m_Inputs; } }

		[SerializeField]
		ScriptableValue m_Value;

		[SerializeField]
		List<ScriptableInput> m_Inputs = new List<ScriptableInput>();
	}
}
