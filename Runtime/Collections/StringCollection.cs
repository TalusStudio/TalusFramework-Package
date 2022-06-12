using UnityEngine;

using TalusFramework.Collections.Interfaces;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New String Collection", menuName = "Collections/String", order = 5)]
    public class StringCollection : BaseCollection<string>
    { }
}