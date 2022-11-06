using System;

using UnityEngine;
using UnityEngine.AddressableAssets;

using TalusFramework.Behaviours.Interfaces;

namespace TalusFramework.AssetManagement
{
    [DisallowMultipleComponent]
    public class NotifyOnDestroy : BaseBehaviour
    {
        public event Action<AssetReferenceGameObject, NotifyOnDestroy> OnDestroyed;
        public AssetReferenceGameObject AssetReference { get; set; }

        public void OnDestroy()
        {
            OnDestroyed?.Invoke(AssetReference, this);
        }
    }
}
