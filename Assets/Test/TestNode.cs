using UnityEngine;
using System;
using NodeFramework.Scriptable;

[Serializable]
public class TestNode : ScriptableNode<ScriptableInput,ScriptableOutput>
{
	public Rect rect { get { return m_Rect; } set { m_Rect = value; } }

	[SerializeField]
	Rect m_Rect;
}
