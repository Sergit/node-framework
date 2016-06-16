using System.Collections.Generic;

namespace NodeFramework.Core
{
	public class Node<TInput,TOutput,TNodeStorage> : INode<TInput,TOutput> where TNodeStorage : INodeStorage<TInput,TOutput>
	{
		public List<TInput> inputs { get { return m_NodeStorage.inputs; } }
		public List<TOutput> outputs { get { return m_NodeStorage.outputs; } }

		public Node(TNodeStorage _storage)
		{
			m_NodeStorage = _storage;
		}

		public TNodeStorage nodeStorage { get { return m_NodeStorage; } }

		TNodeStorage m_NodeStorage;
	}
}
