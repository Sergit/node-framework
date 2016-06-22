using UnityEngine;
using UnityEditor;
using System;
using NodeFramework.Scriptable;

namespace NodeEditor
{
	[Serializable][CreateAssetMenu]
	public class GraphAsset : Graph
	{
		protected override ScriptableInstanceCreator GetCreator()
		{
			return AssetInstanceCreator.Create(this);
		}
	}
}
