using NodeFramework.Core;
using System.Collections.Generic;

namespace NodeFramework.Object
{
	public class DefaultInput : Input {}

	public class DefaultOutput : Output<DefaultInput> {}

	public class DefaultStorage : ListStorage<DefaultInput,DefaultOutput> {}

	public class DefaultCreator : ICreator<DefaultInput,DefaultOutput>
	{
		public DefaultInput CreateInput()
		{
			return new DefaultInput();
		}

		public DefaultOutput CreateOutput()
		{
			return new DefaultOutput();
		}
	}

	public class DefaultNode : Node<DefaultInput, DefaultOutput, DefaultStorage, DefaultCreator>
	{
		public DefaultNode() : base( new DefaultStorage(), new DefaultCreator() ) {}
	}
}