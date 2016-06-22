using System.Collections.Generic;

namespace NodeFramework.Core
{
	public interface IGraph<TNode>
	{
		List<TNode> nodes { get; }
	}
}
