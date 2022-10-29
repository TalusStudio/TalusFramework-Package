using UnityEngine;
using UnityEngine.Events;

using TalusFramework.Behaviours.Interfaces;

using Cinemachine;

namespace TalusFramework.Behaviours.CM
{
    [AddComponentMenu("TalusFramework/Behaviours/Cinemachine/Blend Finished Notifier", 0)]
    public class CmBlendFinishedNotifier : BaseBehaviour
    {
        public UnityEvent<CinemachineVirtualCameraBase> OnBlendFinished;

        private CinemachineVirtualCameraBase _Vcam;

        protected override void Awake()
        {
            _Vcam = GetComponent<CinemachineVirtualCameraBase>();
        }

        protected override void Start()
        {
            ConnectToVcam(true);
            enabled = false;
        }

        private void ConnectToVcam(bool connect)
        {
            var vcam = _Vcam as CinemachineVirtualCamera;
            if (vcam != null)
            {
                vcam.m_Transitions.m_OnCameraLive.RemoveListener(OnCameraLive);
                if (connect)
                {
                    vcam.m_Transitions.m_OnCameraLive.AddListener(OnCameraLive);
                }
            }

            var freeLook = _Vcam as CinemachineFreeLook;
            if (freeLook != null)
            {
                freeLook.m_Transitions.m_OnCameraLive.RemoveListener(OnCameraLive);
                if (connect)
                {
                    freeLook.m_Transitions.m_OnCameraLive.AddListener(OnCameraLive);
                }
            }
        }

        private void OnCameraLive(ICinemachineCamera vcamIn, ICinemachineCamera vcamOut)
        {
            enabled = true;
        }

        private void Update()
        {
            CinemachineBrain brain = CinemachineCore.Instance.FindPotentialTargetBrain(_Vcam);
            if (brain == null)
            {
                enabled = false;
            }
            else if (!brain.IsBlending)
            {
                if (brain.IsLive(_Vcam))
                {
                    OnBlendFinished.Invoke(_Vcam);
                }

                enabled = false;
            }
        }
    }
}
