using UnityEngine;

using Sirenix.OdinInspector;

namespace TalusFramework.Base
{
    public abstract class BaseEvent : BaseSO
    {
        [FoldoutGroup("Debugging")]
        [LabelWidth(60)]
        [AssetList(AssetNamePrefix = "Logger_")]
        public Utility.Logging.Logger Logger;
    }
}
