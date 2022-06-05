using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Utility;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Scene Collection", menuName = "Collections/Scene", order = 6)]
    public class SceneCollection : BaseCollection<SceneReference>
    { }
}