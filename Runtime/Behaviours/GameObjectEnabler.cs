using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/GameObject Enabler", 3)]
    public class GameObjectEnabler : BaseBehaviour
    {
        [LabelWidth(90)]
        [Required]
        public GameObject GameObject;

        private void Awake()
        {
            this.Assert(GameObject != null, $"GameObject reference is null on {name}!");
        }

        public void Enable()
        {
            GameObject.SetActive(true);
        }
    }
}