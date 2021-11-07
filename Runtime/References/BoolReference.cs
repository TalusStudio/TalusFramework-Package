using System;

using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
	[Serializable]
	public sealed class BoolReference : BaseReference<bool>
	{
		public static implicit operator bool(BoolReference reference) => reference.Value;
	}
}
