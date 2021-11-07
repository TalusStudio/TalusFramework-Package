using System;

using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
	[Serializable]
	public sealed class StringReference : BaseReference<string>
	{
		public static implicit operator string(StringReference reference) => reference.Value;
	}
}
