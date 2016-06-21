using UnityEngine;
using UnityEditor;
using System;
using NodeFramework.Scriptable;

[Serializable]
public class TestNodeAsset : TestNode
{
	public Rect rect { get { return m_Rect; } set { m_Rect = value; SetDirty(); } }

	[ContextMenu("CreateInput")]
	public override ScriptableInput CreateInput()
	{
		ScriptableInput l_input = base.CreateInput();

		SetupScriptableObject(l_input);

		return l_input;
	}

	[ContextMenu("CreateOutput")]
	public override ScriptableOutput CreateOutput()
	{
		ScriptableOutput l_output = base.CreateOutput();

		SetupScriptableObject(l_output);

		return l_output;
	}

	void SetDirty()
	{
		EditorUtility.SetDirty(this);	
	}

	void SetupScriptableObject(UnityEngine.Object o)
	{
		o.hideFlags = HideFlags.HideInHierarchy;

		AssetDatabase.AddObjectToAsset(o,this);

		EditorUtility.SetDirty(o);
		EditorUtility.SetDirty(this);
	}

	[SerializeField]
	Rect m_Rect;
}
