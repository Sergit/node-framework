using UnityEngine;
using System;
using NodeFramework.Scriptable;

namespace NodeEditor
{
	[Serializable]
	public class Graph : ScriptableGraph<Node,Input,Output>
	{
		protected override ScriptableInstanceCreator GetCreator()
		{
			return ScriptableInstanceCreator.Create();
		}

		[ContextMenu("Create Node")]
		public Node CreateNode()
		{
			return CreateNode<Node>();
		}

		[ContextMenu("Create Custom Node")]
		public CustomNode CreateCustomNode()
		{
			return CreateNode(typeof(CustomNode)) as CustomNode;
		}
	}
}
