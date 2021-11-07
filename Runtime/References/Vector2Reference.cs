using System;

using TalusFramework.Runtime.References.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.References
{
	[Serializable]
	public sealed class Vector2Reference : BaseReference<Vector2>
	{
		public static implicit operator Vector2(Vector2Reference reference) => reference.Value;
	}
}
