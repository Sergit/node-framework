using System.Collections.Generic;

namespace NodeFramework.Core
{
	public interface IOutput<T,TInput> where TInput : IInput<T>
	{
		T value { get; set; }
		List<TInput> inputs { get; }
	}
}
