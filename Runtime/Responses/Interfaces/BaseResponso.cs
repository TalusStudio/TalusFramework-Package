using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.Responses.Interfaces
{
    public abstract class BaseResponse : BaseSO
    {
        public abstract void Send();
    }

    public abstract class BaseResponse<T> : BaseResponse
    {
        protected abstract BaseReference<T> Argument { get; }

        public override void Send() { Send(Argument.Value); }
        public abstract void Send(T argument);
    }
}