using UnityEngine;
using UnityEditor;
using System;
using NodeFramework.Scriptable;

[Serializable][CreateAssetMenu]
public class TestGraphAsset : TestGraph
{
	protected override ScriptableInstanceCreator GetCreator()
	{
		return AssetInstanceCreator.Create(this);
	}
}
