using UnityEngine;
using System;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class ScriptableInstanceCreator : ScriptableObject, IInstanceCreator
	{
		public static ScriptableInstanceCreator Create()
		{
			return ScriptableObject.CreateInstance<ScriptableInstanceCreator>();
		}


		public virtual T CreateInstance<T>() where T : ScriptableObject
		{
			return ScriptableObject.CreateInstance<T>();
		}

		public virtual ScriptableObject CreateInstance(Type type)
		{
			return ScriptableObject.CreateInstance(type);
		}

		public virtual ScriptableObject CreateInstance(string className)
		{
			return ScriptableObject.CreateInstance(className);
		}
	}
}