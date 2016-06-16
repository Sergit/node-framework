using System.Collections.Generic;

namespace NodeFramework.Core
{
	public class ListNodeStorage<InputPinType,OutputPinType> : INodeStorage<InputPinType,OutputPinType>
	{
		public List<InputPinType> inputs
		{
			get {
				return m_Inputs;
			}
			set{
				m_Inputs = value;
			}
		}

		public List<OutputPinType> outputs
		{
			get {
				return m_Outputs;
			}
			set{
				m_Outputs = value;
			}
		}

		List<InputPinType> m_Inputs = new List<InputPinType>();
		List<OutputPinType> m_Outputs = new List<OutputPinType>();
	}
}
