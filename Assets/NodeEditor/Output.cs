﻿using UnityEngine;
using System;
using System.Collections;
using NodeFramework.Scriptable;

namespace NodeEditor
{
	[Serializable]
	public class Output : ScriptableOutput<Input>
	{
		public Rect layoutRect { get { return m_LayoutRect; } set { m_LayoutRect = value; } }

		[SerializeField]
		Rect m_LayoutRect;
	}
}
