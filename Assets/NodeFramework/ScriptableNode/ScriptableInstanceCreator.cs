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

		new public virtual T CreateInstance<T>() where T : ScriptableObject
		{
			return ScriptableObject.CreateInstance<T>();
		}

		new public virtual ScriptableObject CreateInstance(Type type)
		{
			return ScriptableObject.CreateInstance(type);
		}

		new public virtual ScriptableObject CreateInstance(string className)
		{
			return ScriptableObject.CreateInstance(className);
		}
	}
}