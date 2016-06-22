using UnityEngine;
using UnityEditor;
using System;
using NodeFramework.Scriptable;

[Serializable][CreateAssetMenu]
public class GraphAsset : Graph
{
	protected override ScriptableInstanceCreator GetCreator()
	{
		return AssetInstanceCreator.Create(this);
	}

	public void DestroyNode(Node node)
	{
		if(node)
		{
			nodes.Remove(node);

			foreach(ScriptableInput input in node.inputs)
			{
				DestroyImmediate(input,true);
			}

			foreach(ScriptableOutput output in node.outputs)
			{
				DestroyImmediate(output,true);
			}

			DestroyImmediate(node,true);
		}
	}
}
