using Sirenix.OdinInspector;

using Logger = TalusFramework.Utility.Logging.Logger;

namespace TalusFramework.Base
{
    public abstract class BaseEvent : BaseSO
    {
        [FoldoutGroup("Debugging")]
        [HideLabel]
        [LabelWidth(60)]
        [AssetList(AssetNamePrefix = "Logger_")]
        public Logger Logger;
    }
}
