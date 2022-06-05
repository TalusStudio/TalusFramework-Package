using TalusFramework.Collections.Interfaces;
using TalusFramework.Utility;

using UnityEngine;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Scene Collection", menuName = "Collections/Scene", order = 6)]
    public class SceneCollection : BaseCollection<SceneReference>
    { }
}