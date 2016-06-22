using UnityEngine;
using System;
using NodeFramework.Scriptable;

namespace NodeEditor
{
	[Serializable]
	public class Node : ScriptableNode<Input,Output>
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
}
