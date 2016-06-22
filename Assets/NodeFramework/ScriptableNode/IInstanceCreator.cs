using UnityEngine;

namespace NodeFramework.Scriptable
{
	public interface IInstanceCreator
	{
		T CreateInstance<T>() where T : ScriptableObject;
	}
}