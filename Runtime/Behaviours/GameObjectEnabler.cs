using Sirenix.OdinInspector;

using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    [AddComponentMenu("TalusFramework/GameObjectEnabler", 3)]
    public class GameObjectEnabler : MonoBehaviour
    {
        [LabelWidth(90)]
        [Required]
        public GameObject GameObject;

        public void Enable() => GameObject.SetActive(true);
    }
}