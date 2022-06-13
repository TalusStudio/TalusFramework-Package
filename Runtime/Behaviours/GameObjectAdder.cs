using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Collections;
using TalusFramework.Behaviours.Interfaces;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/GameObject Adder", 1)]
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