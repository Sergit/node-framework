using NodeFramework.Core;

namespace NodeFramework.Object
{
	public class ObjectInput : Input<object> {}
	public class ObjectOutput : Output<object,ObjectInput> {}
	public class ObjectNodeStorage : ListNodeStorage<ObjectInput,ObjectOutput> {}

	public class ObjectNode : Node<ObjectInput, ObjectOutput, ObjectNodeStorage>
	{
		public ObjectNode() : base( new ObjectNodeStorage() ) {}
	}
}