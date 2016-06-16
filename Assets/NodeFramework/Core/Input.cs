namespace NodeFramework.Core
{
	public class Input<T> : IInput<T>
	{
		public T value { get { return m_Value; } set { m_Value = value; } }

		T m_Value;
	}
}
