using UnityEngine;
using System.Collections;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	public class ScriptableNode : Node<ScriptableInput, ScriptableOutput, ScriptableStorage<ScriptableInput,ScriptableOutput>, ScriptableCreator<ScriptableInput,ScriptableOutput> >
	{
		public ScriptableNode(ScriptableStorage<ScriptableInput,ScriptableOutput> scriptableStorage) : base( scriptableStorage, new ScriptableCreator<ScriptableInput,ScriptableOutput>() ) {}
	}
}
