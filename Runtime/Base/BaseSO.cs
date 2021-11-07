using Sirenix.OdinInspector;

using UnityEngine;

// (disable "assigned but never used" warning)
#pragma warning disable 414

namespace TalusFramework.Runtime.Base
{
	/// <summary>
	///     Base class for Scriptable Objects in Talus Framework.
	/// </summary>
	public abstract class BaseSO : ScriptableObject
	{
		[PropertyOrder(0)] [HideLabel]
		[TextArea(5, 10)] [FoldoutGroup("Developer Description")]
		[SerializeField]
		private string DeveloperDescription = "";
	}
}
