using UnityEngine;

using TalusFramework.Collections.Interfaces;
using TalusFramework.Utility;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Scene Collection", menuName = "Collections/Scene", order = 10)]
    public class SceneCollection : BaseCollection<SceneReference>
    { }
}