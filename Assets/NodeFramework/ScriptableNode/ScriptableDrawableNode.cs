using UnityEngine;
using System;
using System.Collections;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class ScriptableDrawableNode : Node<ScriptableInput, ScriptableOutput, ScriptableDrawableNodeStorage>
	{
		public ScriptableDrawableNode(ScriptableDrawableNodeStorage scriptableDrawableNodeStorage) : base( scriptableDrawableNodeStorage ) {}

		public Rect rect { get { return nodeStorage.rect; } set { nodeStorage.rect = value; } }
	}
}
