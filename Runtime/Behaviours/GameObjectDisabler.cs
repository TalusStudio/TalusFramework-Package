using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections;
using TalusFramework.Runtime.Behaviours.Interfaces;

namespace TalusFramework.Runtime.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/GameObjectDisabler", 2)]
    public class GameObjectDisabler : BaseBehaviour
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