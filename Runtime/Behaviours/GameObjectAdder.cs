using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Collections;
using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    /// <summary>
    ///     To save object references on Collection.
    /// </summary>
    [AddComponentMenu("TalusFramework/Behaviours/GameObject Adder", 1)]
    public class GameObjectAdder : BaseBehaviour
    {
        [LabelWidth(60)]
        [AssetSelector, Required]
        public GameObjectCollection Collection;

        protected override void Awake()
        {
            this.Assert(Collection != null, "Invalid Reference!", typeof(GameObjectCollection), null);
        }

        protected override void OnEnable()
        {
            Collection.Add(gameObject);
        }

        protected override void OnDisable()
        {
            Collection.Remove(gameObject);
        }
    }
}