using UnityEngine;

using TalusFramework.Systems.Interfaces;

namespace TalusFramework.Systems
{
    [CreateAssetMenu]
    public class PrefabFactory : AbstractFactory<GameObject>
    {
        public override GameObject Create()
        {
            return Instantiate(Object);
        }
    }
}