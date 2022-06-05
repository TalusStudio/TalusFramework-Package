using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Color Variable", menuName = "Variables/Color", order = 8)]
    public sealed class ColorVariable : BaseVariable<Color>
    { }
}
