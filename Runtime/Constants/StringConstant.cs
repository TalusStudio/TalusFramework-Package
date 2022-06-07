using TalusFramework.Constants.Interfaces;

using UnityEngine;

namespace TalusFramework.Constants
{
    [CreateAssetMenu(fileName = "New String Constant", menuName = "Constants/String", order = 5)]
    public sealed class StringConstant : BaseConstant<string>
    { }
}