using System.Collections.Generic;

namespace NodeFramework.Core
{
	public interface INode<TInput,TOutput>
	{
		List<TInput> inputs { get; }
		List<TOutput> outputs { get; }

		void OnCreate();

		TInput CreateInput();
		TOutput CreateOutput();
		void DestroyInput(TInput input);
		void DestroyOutput(TOutput output);
		void Clear();
	}
}
