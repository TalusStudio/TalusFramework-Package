using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Sprite Variable", menuName = "Variables/Sprite", order = 7)]
    public sealed class SpriteVariable : BaseVariable<Sprite>
    { }
}
