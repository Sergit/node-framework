using System.Collections.Generic;

namespace NodeFramework.Core
{
	public class Node<TInput,TOutput,TStorage,TCreator> : INode<TInput,TOutput> 
		where TStorage : IStorage<TInput,TOutput>
		where TCreator : ICreator<TInput,TOutput>
	{
		public List<TInput> inputs { get { return m_Storage.inputs; } }
		public List<TOutput> outputs { get { return m_Storage.outputs; } }

		public Node(TStorage _storage, TCreator _creator)
		{
			m_Storage = _storage;
			m_Creator = _creator;
		}

		public TInput CreateInput()
		{
			return m_Creator.CreateInput();
		}

		public TOutput CreateOutput()
		{
			return m_Creator.CreateOutput();
		}

		public TStorage storage { get { return m_Storage; } }

		TStorage m_Storage;
		TCreator m_Creator;
	}
}
