namespace NodeFramework.Core
{
	public class InputValue<T> : Input
	{
		public T value { get { return m_Value; } set { m_Value = value; } }

		T m_Value;
	}
}
