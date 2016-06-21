using UnityEngine;
using UnityEditor;
using System;
using NodeFramework.Scriptable;

[Serializable][CreateAssetMenu]
public class TestGraphAsset : TestGraph
{
	[ContextMenu("CreateNode")]
	public override TestNode CreateNode()
	{
		TestNodeAsset l_node = ScriptableObject.CreateInstance<TestNodeAsset>();

		nodes.Add(l_node);

		l_node.hideFlags = HideFlags.HideInHierarchy;

		AssetDatabase.AddObjectToAsset(l_node,this);

		EditorUtility.SetDirty(l_node);
		EditorUtility.SetDirty(this);

		return l_node;
	}
}
