using TalusFramework.Base;

namespace TalusFramework.Managers.Interfaces
{
    public abstract class BaseManager : BaseSO, IInitable
    {
        public abstract void Initialize();
    }
}
