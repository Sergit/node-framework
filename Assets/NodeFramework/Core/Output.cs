using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Core
{
	public class Output<T,TInput> : IOutput<T,TInput> where TInput : IInput<T>
	{
		public T value { get { return m_Value; } set { m_Value = value; } }

		public List<TInput> inputs { get { return m_Inputs; } }

		T m_Value;

		List<TInput> m_Inputs = new List<TInput>();
	}
}
