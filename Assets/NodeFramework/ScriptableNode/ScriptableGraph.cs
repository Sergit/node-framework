using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public abstract class ScriptableGraph<TNode> : ScriptableObject, IGraph<TNode>
		where TNode : ScriptableNode<ScriptableInput,ScriptableOutput>
	{
		public List<TNode> nodes { get { return m_Nodes; } }

		public ScriptableInstanceCreator creator {
			get {

				if(!m_Creator)
				{
					m_Creator = GetCreator();
				}

				return m_Creator;
			}
			set {
				m_Creator = value;
			}
		}
			
		public T CreateNode<T>() where T : TNode
		{
			TNode l_node = default(TNode);

			if(creator)
			{
				l_node = creator.CreateInstance<T>() as TNode;

				l_node.creator = creator;

				nodes.Add(l_node);
			}

			return l_node as T;
		}

		protected abstract ScriptableInstanceCreator GetCreator();

		[SerializeField][HideInInspector]
		ScriptableInstanceCreator m_Creator;

		[SerializeField]
		List<TNode> m_Nodes = new List<TNode>();
	}
}
