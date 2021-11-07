using Sirenix.OdinInspector;

using UnityEngine;

namespace TalusFramework.Runtime.Base
{
	/// <summary>
	///     To work with UnityEditor & UnityEvent.
	/// </summary>
	public abstract class BaseValueSO : BaseSO { }

	/// <summary>
	///     Base Variable Class, use RunTimeValue property if u need reference.
	/// </summary>
	/// <typeparam name="TPlainType">Serializable type.</typeparam>
	public class BaseValueSO<TPlainType> : BaseValueSO, ISerializationCallbackReceiver
	{
		[SerializeField]
		[DisableInPlayMode]
		[OnValueChanged("@RuntimeValue = Value")]
		[AssetsOnly]
		private TPlainType _Value;

		[SerializeField]
		[DisableInEditorMode]
		[AssetsOnly]
		private TPlainType _RuntimeValue;

		public TPlainType Value => _Value;

		public TPlainType RuntimeValue
		{
			get => _RuntimeValue;
			protected set => _RuntimeValue = value;
		}

		public virtual void OnBeforeSerialize() { }

		public virtual void OnAfterDeserialize()
		{
			RuntimeValue = Value;
		}
	}
}
