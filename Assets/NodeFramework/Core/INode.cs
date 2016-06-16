using System.Collections.Generic;

namespace NodeFramework.Core
{
	public interface INode<TInput,TOutput>
	{
		List<TInput> inputs { get; }
		List<TOutput> outputs { get; }
	}
}
