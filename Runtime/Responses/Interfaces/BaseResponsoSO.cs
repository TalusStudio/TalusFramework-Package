using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.Responses.Interfaces
{
    public abstract class BaseResponseSO : BaseSO
    {
        public abstract void Send();
    }

    public abstract class BaseResponseSO<T> : BaseResponseSO
    {
        protected abstract BaseReference<T> Argument { get; }
        public override void Send() { Send(Argument.Value); }

        public abstract void Send(T argument);
    }
}
