using TalusFramework.Base;

namespace TalusFramework.Constants.Interfaces
{
    public abstract class BaseConstant<TPlainType> : BaseValue<TPlainType>
    {
        public sealed override TPlainType RuntimeValue
        {
            get => base.RuntimeValue;
            protected set => base.RuntimeValue = value;
        }
    }
}