using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class ScriptableGraph<TNode> : ScriptableObject, IGraph<TNode>
		where TNode : ScriptableNode<ScriptableInput,ScriptableOutput>
	{
		public List<TNode> nodes { get { return m_Nodes; } }

		public virtual TNode CreateNode()
		{
			TNode l_node = ScriptableObject.CreateInstance<TNode>();

			nodes.Add(l_node);

			return l_node;
		}

		[SerializeField]
		List<TNode> m_Nodes = new List<TNode>();
	}
}
