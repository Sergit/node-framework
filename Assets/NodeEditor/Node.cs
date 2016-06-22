using UnityEngine;
using System;
using NodeFramework.Scriptable;

[Serializable]
public class Node : ScriptableNode<ScriptableInput,ScriptableOutput>
{
	public string header { get { return GetHeader(); } }

	public Rect rect { get { return m_Rect; } set { m_Rect = value; } }

	protected virtual string GetHeader()
	{
		return "Node";
	}

	[SerializeField]
	Rect m_Rect;
}
