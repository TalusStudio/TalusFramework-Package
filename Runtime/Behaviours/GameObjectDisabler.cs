using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Collections;
using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/GameObject Disabler", 2)]
    public class GameObjectDisabler : BaseBehaviour
    {
        [LabelWidth(60)]
        [AssetList(AssetNamePrefix = "Collection_")]
        [Required]
        public GameObjectCollection Collection;
        
        public void Disable(int index)
        {
            this.Assert(index <= Collection.Count - 1, "Invalid collection index!");

            Collection[index].SetActive(false);
        }

        public void DisableAll()
        {
            Collection.ForEach(gameObj => gameObj.SetActive(false));
        }

        public void DisableRandom()
        {
            int index = Random.Range(0, Collection.Count);
            Collection[index].SetActive(false);
        }
    }
}