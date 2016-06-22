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
}
