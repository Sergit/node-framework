using UnityEngine;
using System;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable][CreateAssetMenu]
	public class ScriptableInput : ScriptableObject, IInput<ScriptableValue>
	{
		public ScriptableValue value { get { return m_Value; } set { m_Value = value; } }

		[SerializeField]
		ScriptableValue m_Value;
	}
}
