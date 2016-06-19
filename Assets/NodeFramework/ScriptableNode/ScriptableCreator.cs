using UnityEngine;
using System;
using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class ScriptableCreator<TInput,TOutput> : ICreator<TInput,TOutput> where TInput : ScriptableInput where TOutput : ScriptableOutput
	{
		public TInput CreateInput()
		{
			return ScriptableObject.CreateInstance<TInput>();
		}

		public TOutput CreateOutput()
		{
			return ScriptableObject.CreateInstance<TOutput>();
		}
	}
}
