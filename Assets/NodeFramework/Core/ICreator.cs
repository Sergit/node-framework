using UnityEngine;
using System.Collections;

namespace NodeFramework.Core
{
	public interface ICreator<TInput,TOutput>
	{
		TInput CreateInput();
		TOutput CreateOutput();
	}
}
