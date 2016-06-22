using UnityEngine;
using UnityEditor;
using System;

namespace NodeFramework.Scriptable
{
	[Serializable]
	public class AssetInstanceCreator : ScriptableInstanceCreator
	{
		public static AssetInstanceCreator Create(ScriptableObject _asset)
		{
			AssetInstanceCreator l_creator = ScriptableObject.CreateInstance<AssetInstanceCreator>();

			l_creator.m_Asset = _asset;

			SetupScriptableObject(l_creator,_asset);

			return l_creator;
		}

		public override T CreateInstance<T>()
		{
			T l_instance = base.CreateInstance<T>();

			SetupScriptableObject(l_instance,m_Asset);

			return l_instance;
		}

		public override ScriptableObject CreateInstance(Type type)
		{
			ScriptableObject l_instance = base.CreateInstance(type);

			SetupScriptableObject(l_instance,m_Asset);

			return l_instance;
		}

		public override ScriptableObject CreateInstance(string className)
		{
			ScriptableObject l_instance = base.CreateInstance(className);

			SetupScriptableObject(l_instance,m_Asset);

			return l_instance;
		}

		static void SetupScriptableObject(ScriptableObject _instance, ScriptableObject _asset)
		{
			_instance.hideFlags = HideFlags.HideInHierarchy;

			AssetDatabase.AddObjectToAsset(_instance,_asset);

			EditorUtility.SetDirty(_instance);
			EditorUtility.SetDirty(_asset);
		}

		[SerializeField]
		ScriptableObject m_Asset;
	}
}