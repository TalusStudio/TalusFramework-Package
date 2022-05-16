using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections;
using TalusFramework.Runtime.Behaviours.Interfaces;

namespace TalusFramework.Runtime.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/GameObjectAdder", 1)]
    public class GameObjectAdder : BaseBehaviour
    {
        [LabelWidth(60)]
        [AssetSelector, Required]
        public GameObjectCollection Collection;

        private void OnEnable()
        {
            Collection.Add(gameObject);
        }

        private void OnDisable()
        {
            Collection.Remove(gameObject);
        }
    }
}