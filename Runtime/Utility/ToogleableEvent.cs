using System;
using Sirenix.OdinInspector;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Utility
{
    [Serializable, Toggle("Enabled")]
    public class ToggleableEvent
    {
        public bool Enabled;
        public UnityEvent Response;
    }
}
