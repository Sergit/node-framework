using NodeFramework.Core;
using System.Collections.Generic;

namespace NodeFramework.Default
{
	public class DefaultInput : Input {}

	public class DefaultOutput : Output<DefaultInput> {}

	public class DefaultNode : Node<DefaultInput, DefaultOutput> {}
}