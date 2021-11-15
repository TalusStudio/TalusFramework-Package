using Sirenix.OdinInspector;

using TalusFramework.Runtime.Constants.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
    [CreateAssetMenu(fileName = "New Vector2 Constant", menuName = "Constants/Vector2", order = 4)]
    [HideMonoScript]
    public sealed class Vector2ConstantSO : BaseConstantSO<Vector2>
    { }
}
