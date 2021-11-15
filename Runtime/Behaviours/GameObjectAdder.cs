using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections;

using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class GameObjectAdder : MonoBehaviour
    {
        [LabelWidth(75)]
        [AssetSelector]
        [Required]
        public GameObjectCollectionSO CollectionSo;

        private void OnEnable()
        {
            CollectionSo.Add(gameObject);
        }

        private void OnDisable()
        {
            CollectionSo.Remove(gameObject);
        }
    }
}
