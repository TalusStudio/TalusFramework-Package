using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Color Variable", menuName = "Variables/Color", order = 8)]
    public sealed class ColorVariableSO : BaseVariableSO<Color>
    { }
}
