using System;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Events;
using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New Debug Data", menuName = "Managers/Debug Data", order = 0)]
    [HideMonoScript]
    public class DebugDataSO : BaseSO
    {
        [FoldoutGroup("Debugging")]
        [ToggleLeft]
        [SerializeField]
        private bool _EnableHiddenDebugView;

        [ShowIf("_EnableHiddenDebugView")]
        [FoldoutGroup("Debugging")]
        [LabelWidth(145)]
        [AssetSelector]
        public GameObjectConstantSO DebugView;

        [ShowIf("_EnableHiddenDebugView")]
        [FoldoutGroup("Debugging")]
        [LabelWidth(145)]
        [SerializeField]
        public IntReference RequiredTapCount;

        [ShowIf("_EnableHiddenDebugView")]
        [FoldoutGroup("Debugging")]
        [LabelWidth(145)]
        [AssetSelector]
        [Required]
        public GameEvent ConsoleActivatedEvent;

        [NonSerialized]
        private int _CurrentTapCount;

        public void CreateDebugView()
        {
            if (!_EnableHiddenDebugView)
            {
                TLog.Log("Quantum Console disabled in Build Settings!!!", LogType.Warning);
                return;
            }

            if (GameObject.Find("UI_Canvas_Debug") == null)
            {
                Instantiate(DebugView.RuntimeValue);
            }
            else
            {
                TLog.Log("Quantum Console binding already in scene!");
            }
        }

        public void CheckConsoleActivity()
        {
            if (++_CurrentTapCount >= RequiredTapCount)
            {
                _CurrentTapCount = 0;

                ConsoleActivatedEvent.Raise();
            }
        }
    }
}
