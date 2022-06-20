using UnityEngine;

using TalusFramework.Variables.Interfaces;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New GameObject Variable", menuName = "Variables/GameObject", order = 9)]
    public sealed class GameObjectVariable : BaseVariable<GameObject>
    {
        public override bool AreValuesEqual(GameObject value) => ReferenceEquals(RuntimeValue, value);
    }
}
