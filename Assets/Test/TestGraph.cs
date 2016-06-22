using UnityEngine;
using System;
using NodeFramework.Scriptable;

[Serializable]
public class TestGraph : ScriptableGraph<TestNode>
{
	[ContextMenu("CreateTestNode")]
	public TestNode CreateTestNode()
	{
		return CreateNode<TestNode>();
	}

	[ContextMenu("CreateCustomNode")]
	public CustomNode CreateCustomNode()
	{
		return CreateNode<CustomNode>();
	}
		
	protected override ScriptableInstanceCreator GetCreator()
	{
		return ScriptableInstanceCreator.Create();
	}
}
