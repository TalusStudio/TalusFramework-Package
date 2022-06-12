using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/GameObjectEnabler", 3)]
    public class GameObjectEnabler : BaseBehaviour
    {
        [LabelWidth(90)]
        [Required]
        public GameObject GameObject;

        public void Enable()
        {
            GameObject.SetActive(true);
        }
    }
}