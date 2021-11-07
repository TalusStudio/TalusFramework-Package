using System;

using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
	[Serializable]
	public sealed class IntReference : BaseReference<int>
	{
		public static implicit operator int(IntReference reference) => reference.Value;
	}
}
