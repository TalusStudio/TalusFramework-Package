using TalusFramework.Base;
using TalusFramework.Events.Interfaces;

namespace TalusFramework.Responses.Interfaces
{
    public abstract class BaseResponse : BaseSO, IGameEventListener
    {
        public abstract void Send();
    }

    public abstract class BaseResponse<T> : BaseSO, IGameEventListener<T>
    {
        public abstract void Send(T argument);
    }
}