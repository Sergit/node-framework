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

			l_creator.hideFlags = HideFlags.HideInHierarchy;

			AssetDatabase.AddObjectToAsset(l_creator,_asset);

			EditorUtility.SetDirty(l_creator);
			EditorUtility.SetDirty(_asset);

			return l_creator;
		}

		public override T CreateInstance<T>()
		{
			T l_instance = base.CreateInstance<T>();

			l_instance.hideFlags = HideFlags.HideInHierarchy;

			AssetDatabase.AddObjectToAsset(l_instance,m_Asset);

			EditorUtility.SetDirty(l_instance);
			EditorUtility.SetDirty(m_Asset);

			return l_instance;
		}

		[SerializeField]
		ScriptableObject m_Asset;
	}
}