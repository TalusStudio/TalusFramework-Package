using Sirenix.OdinInspector;

using TalusFramework.Runtime.Behaviours;
using TalusFramework.Runtime.Sets.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Sets
{
	[CreateAssetMenu(fileName = "New Thing Runtime Set", menuName = "Collections/Thing Runtime Set", order = 4)]
	[HideMonoScript]
	public class ThingRuntimeSet : RuntimeSet<Thing> { }
}
