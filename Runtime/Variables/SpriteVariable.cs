using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Sprite Variable", menuName = "Variables/Sprite", order = 7)]
    public sealed class SpriteVariable : BaseVariable<Sprite>
    {
        public override bool AreValuesEqual(Sprite value) => ReferenceEquals(RuntimeValue, value);
    }
}
