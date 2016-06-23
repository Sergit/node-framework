using System.Collections.Generic;

namespace NodeFramework.Core
{
	public class Output<TInput> : IOutput<TInput> where TInput : IInput
	{
		public List<TInput> inputs { get { return m_Inputs; } }

		public void AddInput(TInput input)
		{
			if(!inputs.Contains(input))
			{
				inputs.Add(input);
			}
		}

		List<TInput> m_Inputs = new List<TInput>();
	}
}