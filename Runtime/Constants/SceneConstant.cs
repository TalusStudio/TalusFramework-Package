using TalusFramework.Constants.Interfaces;
using TalusFramework.Utility;

using UnityEngine;

namespace TalusFramework.Constants
{
    [CreateAssetMenu(fileName = "New Scene Constant", menuName = "Constants/Scene", order = 10)]
    public sealed class SceneConstant : BaseConstant<SceneReference>
    {
        public override void ResetValueAfterDeserialize()
        {
            if (Value != null && !Value.IsEmpty)
            {
                RuntimeValue = Value.Clone();
            }
        }
    }
}