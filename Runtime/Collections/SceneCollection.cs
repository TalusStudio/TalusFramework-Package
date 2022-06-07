using TalusFramework.Collections.Interfaces;
using TalusFramework.Utility;

using UnityEngine;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Scene Collection", menuName = "Collections/Scene", order = 10)]
    public class SceneCollection : BaseCollection<SceneReference>
    { }
}