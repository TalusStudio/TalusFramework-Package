using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections;

using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    [AddComponentMenu("TalusFramework/Behaviours/GameObjectAdder", 1)]
    public class GameObjectAdder : MonoBehaviour
    {
        [LabelWidth(60)]
        [AssetSelector, Required]
        public GameObjectCollectionSO Collection;

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