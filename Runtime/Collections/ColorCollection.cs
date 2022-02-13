using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Color Collection", menuName = "Collections/Color", order = 1)]
    public class ColorCollection : BaseCollection<Color>
    { }
}