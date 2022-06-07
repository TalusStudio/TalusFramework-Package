using TalusFramework.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Responses
{
    [CreateAssetMenu(fileName = "New Color Response", menuName = "Responses/Color", order = 7)]
    public sealed class ColorResponse : Response<Color>
    { }
}
