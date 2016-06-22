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
			T l_node = default(T);

			if(creator)
			{
				l_node = creator.CreateInstance<T>();

				SetupNode(l_node);
			}

			return l_node;
		}

		public TNode CreateNode(Type type)
		{
			TNode l_node = default(TNode);

			if(creator)
			{
				l_node = creator.CreateInstance(type) as TNode;

				SetupNode(l_node);
			}

			return l_node;
		}

		public TNode CreateNode(string className)
		{
			TNode l_node = default(TNode);

			if(creator)
			{
				l_node = creator.CreateInstance(className) as TNode;

				SetupNode(l_node);
			}

			return l_node;
		}

		public void DestroyNode(TNode node)
		{
			if(creator && nodes.Contains(node))
			{
				nodes.Remove(node);

				creator.DestroyInstance(node);
			}
		}

		void SetupNode(TNode _node)
		{
			if(_node)
			{
				_node.creator = creator;

				nodes.Add(_node);

				_node.OnCreate();
			}
		}

		protected abstract ScriptableInstanceCreator GetCreator();

		[SerializeField][HideInInspector]
		ScriptableInstanceCreator m_Creator;

		[SerializeField]
		List<TNode> m_Nodes = new List<TNode>();
	}
}
