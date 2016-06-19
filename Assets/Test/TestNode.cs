using UnityEngine;
using System;
using System.Collections;
using NodeFramework.Core;
using NodeFramework.Scriptable;

[Serializable]
public class TestStorage : ScriptableStorage<ScriptableInput,ScriptableOutput>
{
	public Rect rect { get { return m_Rect; } set { m_Rect = value; } }

	[SerializeField]
	Rect m_Rect;
}

public class TestCreator : ScriptableCreator<ScriptableInput,ScriptableOutput> {}

public class TestNode : Node<ScriptableInput, ScriptableOutput, TestStorage, TestCreator>
{
	public TestNode(TestStorage storage) : base( storage, new TestCreator() ) {}

	public Rect rect { get { return storage.rect; } set { storage.rect = value; } }
}
