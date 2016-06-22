using UnityEngine;
using System;
using System.Collections;
using NodeFramework.Scriptable;

namespace NodeEditor
{
	[Serializable]
	public class Input : ScriptableInput
	{
		public Vector2 position { get { return m_Position; } set { m_Position = value; } }

		[SerializeField]
		Vector2 m_Position;
	}
}
