using TalusFramework.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Color Collection", menuName = "Collections/Color", order = 6)]
    public class ColorCollection : BaseCollection<Color>
    { }
}