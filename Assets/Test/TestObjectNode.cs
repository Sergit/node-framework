using UnityEngine;
using System.Collections;
using NodeFramework.Object;
using NodeFramework.Scriptable;

[ExecuteInEditMode]
public class TestObjectNode : MonoBehaviour
{
	RectTransform rectTransform;

	[SerializeField]
	ScriptableDrawableNodeStorage m_ScriptableDrawableNodeStorage;

	void Awake()
	{
		rectTransform = GetComponent<RectTransform>();

		if(m_ScriptableDrawableNodeStorage)
		{
			ScriptableDrawableNode node = new ScriptableDrawableNode(m_ScriptableDrawableNodeStorage);

			//Debug.Log(node);
		}
	}

	void Update()
	{
		if(rectTransform && m_ScriptableDrawableNodeStorage)
		{
			m_ScriptableDrawableNodeStorage.rect = new Rect(rectTransform.localPosition, rectTransform.rect.size);
		}
	}
}
