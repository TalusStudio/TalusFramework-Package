using Sirenix.OdinInspector;

using TalusFramework.Runtime.Constants.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
    [CreateAssetMenu(fileName = "New Float Constant", menuName = "Constants/Float", order = 1)]
    [HideMonoScript]
    public sealed class FloatConstantSO : BaseConstantSO<float>
    { }
}
