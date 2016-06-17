using UnityEngine;
using System;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable][CreateAssetMenu]
	public class ScriptableOutput : ScriptableObject, IOutput<ScriptableInput>
	{
		public List<ScriptableInput> inputs { get { return m_Inputs; } }

		[SerializeField]
		List<ScriptableInput> m_Inputs = new List<ScriptableInput>();
	}
}
