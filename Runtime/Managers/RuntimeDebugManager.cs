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
    [CreateAssetMenu(fileName = "New Runtime Debug Manager", menuName = "Managers/Runtime Debug Manager", order = 2)]
    public class RuntimeDebugManager : BaseSO, IInitializable
    {
#if UNITY_EDITOR
        private bool IsCommandsActivated()
        {
            #if ENABLE_COMMANDS
            return true;
            #else
            return false;
            #endif
        }

        [ShowIf("@IsCommandsActivated() == false")]
        [Title("Command definition can not found!")]
        [GUIColor(0f, 1f, 0f)]
        [Button(ButtonSizes.Large)]
        public void AddCommandDefinition()
        {

        }
#endif

        [ToggleLeft]
        [SerializeField]
        private bool _EnableHiddenDebugView;

        [ShowIf("_EnableHiddenDebugView")]
        [LabelWidth(145)]
        [AssetSelector]
        public GameObjectConstant DebugView;

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
            if (!_EnableHiddenDebugView) { return; }

#if ENABLE_COMMANDS
            if (GameObject.Find("UI_Canvas_Debug") != null)
            {
                TLog.Log("Debugging Canvas(hidden) already in scene!", this);
                return;
            }

            _CurrentTapCount = 0;

            Instantiate(DebugView.RuntimeValue);
#else
            TLog.Log("'ENABLE_COMMANDS' definition not found!", this, LogType.Error);
#endif
        }

        public void CheckConsoleActivity()
        {
#if ENABLE_COMMANDS
            if (++_CurrentTapCount < RequiredTapCount)
            {
                return;
            }

            _CurrentTapCount = 0;

            var runtimeConsole = FindObjectOfType<QuantumConsole>();
            if (runtimeConsole != null)
            {
                runtimeConsole.Activate();
            }
            else
            {
                ConsoleActivatedEvent.Raise();
            }
#else
            TLog.Log("'ENABLE_COMMANDS' definition not found!", this, LogType.Error);
#endif
        }
    }
}