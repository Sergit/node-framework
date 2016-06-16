using System.Collections.Generic;

namespace NodeFramework.Core
{
	public interface INodeStorage<TInput,TOutput>
	{
		List<TInput> inputs { get; set; }
		List<TOutput> outputs { get; set; }
	}
}
