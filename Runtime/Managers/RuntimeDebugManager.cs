using System;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Events;
using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;

#if ENABLE_COMMANDS
using QFSW.QC;
#endif

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New Runtime Debug Manager", menuName = "Managers/Runtime Debug Manager", order = 0)]
    public class RuntimeDebugManager : BaseSO, IInitializable
    {
        [ToggleLeft]
        [SerializeField]
        private bool _EnableHiddenDebugView;

        [ShowIf("_EnableHiddenDebugView")]
        [LabelWidth(145)]
        [AssetSelector]
        public GameObjectConstantSO DebugView;

        [ShowIf("_EnableHiddenDebugView")]
        [LabelWidth(145)]
        [SerializeField]
        public IntReference RequiredTapCount;

        [ShowIf("_EnableHiddenDebugView")]
        [LabelWidth(145)]
        [AssetSelector, Required]
        public GameEvent ConsoleActivatedEvent;

        [NonSerialized]
        private int _CurrentTapCount;

        public void Initialize()
        {
            if (!_EnableHiddenDebugView)
            {
                TLog.Log("Quantum Console disabled in Debug Data SO!!!", LogType.Warning);
                return;
            }

            if (GameObject.Find("UI_Canvas_Debug") != null)
            {
                TLog.Log("Quantum Console binding already in scene!");
                return;
            }

            Instantiate(DebugView.RuntimeValue);
        }

        public void CheckConsoleActivity()
        {
#if ENABLE_COMMANDS
            if (++_CurrentTapCount < RequiredTapCount)
            {
                return;
            }

            var runtimeConsole = FindObjectOfType<QuantumConsole>();
            if (runtimeConsole != null)
            {
                runtimeConsole.Activate();
            }
            else
            {
                _CurrentTapCount = 0;
                ConsoleActivatedEvent.Raise();
            }
#else
            TLog.Log("Quantum Console not enabled!", LogType.Error);
#endif
        }
    }
}