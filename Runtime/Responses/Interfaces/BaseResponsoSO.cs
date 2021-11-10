using TalusFramework.Runtime.Base;

using UnityEngine.Events;

namespace TalusFramework.Runtime.Responses.Interfaces
{
	public abstract class BaseResponseSO : BaseSO
	{
		public abstract void Invoke();
	}

	public abstract class BaseResponseSO<T> : BaseResponseSO
	{
		public abstract UnityEvent<T> Response { get; set; }
	}
}
