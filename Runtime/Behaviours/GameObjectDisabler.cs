using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections;

using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    [AddComponentMenu("TalusFramework/Behaviours/GameObjectDisabler", 2)]
    public class GameObjectDisabler : MonoBehaviour
    {
        [LabelWidth(60)]
        [AssetSelector, Required]
        public GameObjectCollection Collection;

        public void DisableAll()
        {
            for (int i = Collection.Items.Count - 1; i >= 0; i--)
            {
                Collection.Items[i].SetActive(false);
            }
        }

        public void DisableRandom()
        {
            int index = Random.Range(0, Collection.Items.Count);
            Collection.Items[index].SetActive(false);
        }
    }
}