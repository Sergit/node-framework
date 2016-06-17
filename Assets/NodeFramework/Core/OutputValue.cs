using System.Collections.Generic;
using NodeFramework.Core;

namespace NodeFramework.Core
{
	public class OutputValue<T,TInput> : Output<TInput> where TInput : InputValue<T>
	{
		public T value { get { return m_Value; } set { m_Value = value; } }

		T m_Value;
	}
}
