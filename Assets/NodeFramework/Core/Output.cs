using System.Collections.Generic;

namespace NodeFramework.Core
{
	public class Output<TInput> : IOutput<TInput> where TInput : IInput
	{
		public List<TInput> inputs { get { return m_Inputs; } }

		List<TInput> m_Inputs = new List<TInput>();
	}
}