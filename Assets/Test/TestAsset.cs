using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable][CreateAssetMenu]
public class TestAsset : ScriptableObject
{
	[SerializeField]
	List<TestStorage> m_Nodes = new List<TestStorage>();

	public List<TestStorage> nodes { get { return m_Nodes; } }
}
