using UnityEngine;
using System;
using NodeFramework.Scriptable;

[Serializable]
public class Graph : ScriptableGraph<Node>
{
	[ContextMenu("CreateNode")]
	public Node CreateNode()
	{
		return CreateNode<Node>();
	}

	[ContextMenu("CreateCustomNode")]
	public CustomNode CreateCustomNode()
	{
		return CreateNode(typeof(CustomNode)) as CustomNode;
	}
		
	protected override ScriptableInstanceCreator GetCreator()
	{
		return ScriptableInstanceCreator.Create();
	}
}
