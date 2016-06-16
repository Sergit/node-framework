using UnityEngine;
using System.Collections;
using NodeFramework.Object;
using NodeFramework.Scriptable;

public class TestObjectNode : MonoBehaviour
{
	[SerializeField]
	ScriptableNodeStorage m_ScriptableNodeStorage;

	void Awake()
	{
		if(m_ScriptableNodeStorage)
		{
			ScriptableNode node = new ScriptableNode(m_ScriptableNodeStorage);

			Debug.Log(node);
		}
	}
}
