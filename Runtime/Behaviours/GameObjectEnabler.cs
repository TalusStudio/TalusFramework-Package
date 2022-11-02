using System.Collections;

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
        
        public void Enable()
        {
            GameObject.SetActive(true);
        }

        public void EnableWithDelay(float delay)
        {
            StartCoroutine(EnableRoutine(delay));
        }

        private IEnumerator EnableRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);

            GameObject.SetActive(true);
        }
    }
}