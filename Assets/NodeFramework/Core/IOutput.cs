using System.Collections.Generic;

namespace NodeFramework.Core
{
	public interface IOutput<TInput> where TInput : IInput
	{
		List<TInput> inputs { get; }
	}
}
