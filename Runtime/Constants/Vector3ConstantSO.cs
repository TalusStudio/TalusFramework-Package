using Sirenix.OdinInspector;
using TalusFramework.Runtime.Constants.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
    [CreateAssetMenu(fileName = "New Vector3 Constant", menuName = "Constants/Vector3", order = 5)]
    [HideMonoScript]
    public sealed class Vector3ConstantSO : BaseConstantSO<Vector3>
    {
        public override string ToString() => "Const Vector3";
    }
}
