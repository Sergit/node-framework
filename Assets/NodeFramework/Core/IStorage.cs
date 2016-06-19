using System.Collections.Generic;

namespace NodeFramework.Core
{
	public interface IStorage<TInput,TOutput>
	{
		List<TInput> inputs { get; set; }
		List<TOutput> outputs { get; set; }
	}
}
