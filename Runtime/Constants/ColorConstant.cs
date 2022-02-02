using TalusFramework.Runtime.Constants.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
    [CreateAssetMenu(fileName = "New Color Constant", menuName = "Constants/Color", order = 8)]
    public sealed class ColorConstant : BaseConstant<Color>
    { }
}