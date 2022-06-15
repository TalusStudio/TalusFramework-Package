using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Systems;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/Object Creator", 5)]
    public class ObjectCreator : BaseBehaviour
    {
        [LabelWidth(50)]
        [AssetList(AssetNamePrefix = "Factory_")]
        [Required]
        [SerializeField]
        private PrefabFactory _Factory;

        [GUIColor(0f, 1f, 0f)]
        [Button(ButtonSizes.Large), DisableInEditorMode]
        public void Create()
        {
            _Factory.Create();
        }
    }
}