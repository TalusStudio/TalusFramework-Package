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
        [AssetSelector, Required]
        public GameObjectCollection Collection;

        private void Awake()
        {
            this.Assert(Collection != null, $"Collection reference is null on {name}!");
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