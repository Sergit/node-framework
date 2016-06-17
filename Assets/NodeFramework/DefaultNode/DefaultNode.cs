using NodeFramework.Core;
using System.Collections.Generic;

namespace NodeFramework.Object
{
	public class DefaultInput : Input {}

	public class DefaultOutput : Output<DefaultInput> {}

	public class DefaultNodeStorage : ListNodeStorage<DefaultInput,DefaultOutput> {}

	public class DefaultNode : Node<DefaultInput, DefaultOutput, DefaultNodeStorage>
	{
		public DefaultNode() : base( new DefaultNodeStorage() ) {}
	}
}