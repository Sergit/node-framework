using UnityEngine;
using System.Collections;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	public class ScriptableNode : Node<ScriptableInput, ScriptableOutput, ScriptableNodeStorage>
	{
		public ScriptableNode(ScriptableNodeStorage scriptableNodeStorage) : base( scriptableNodeStorage ) {}
	}
}
