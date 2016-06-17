using UnityEngine;
using System;
using System.Collections;
using NodeFramework.Core;

namespace NodeFramework.Scriptable
{
	[Serializable][CreateAssetMenu]
	public class ScriptableDrawableNodeStorage : ScriptableNodeStorage
	{
		public Rect rect { get { return m_Rect; } set { m_Rect = value; } }

		[SerializeField]
		Rect m_Rect;
	}
}
