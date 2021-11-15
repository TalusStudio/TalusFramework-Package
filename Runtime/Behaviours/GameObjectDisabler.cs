using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections;

using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class GameObjectDisabler : MonoBehaviour
    {
        [LabelWidth(25)]
        [AssetSelector]
        [Required]
        public GameObjectCollectionSO Set;

        public void DisableAll()
        {
            for (int i = Set.Items.Count - 1; i >= 0; i--)
            {
                Set.Items[i].gameObject.SetActive(false);
            }
        }

        public void DisableRandom()
        {
            int index = Random.Range(0, Set.Items.Count);
            Set.Items[index].gameObject.SetActive(false);
        }
    }
}
