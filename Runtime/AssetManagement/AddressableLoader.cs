using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Logging;

namespace TalusFramework.AssetManagement
{
    public class AddressableLoader : BaseBehaviour
    {
        [SerializeField] private List<AssetReferenceGameObject> _AssetReferences;

        private readonly Dictionary<AssetReferenceGameObject, List<GameObject>> _SpawnedObjects = 
                new Dictionary<AssetReferenceGameObject, List<GameObject>>();
    
        /// The Queue holds requests to spawn an instanced that were made while we are already loading the asset
        /// They are spawned once the addressable is loaded, in the order requested
        private readonly Dictionary<AssetReferenceGameObject, Queue<Vector3>> _QueuedSpawnRequests = 
                new Dictionary<AssetReferenceGameObject, Queue<Vector3>>();
    
        private readonly Dictionary<AssetReferenceGameObject, AsyncOperationHandle<GameObject>> _AsyncOperationHandles = 
                new Dictionary<AssetReferenceGameObject, AsyncOperationHandle<GameObject>>();

        [Button]
        public void Spawn(int index)
        {
            if (index < 0 || index >= _AssetReferences.Count)
            {
                return;
            }

            AssetReferenceGameObject assetReference = _AssetReferences[index];

            if (assetReference.RuntimeKeyIsValid() == false)
            {
                this.Error("Invalid Key " + assetReference.RuntimeKey);
                return;
            }

            if (_AsyncOperationHandles.ContainsKey(assetReference))
            {
                if (_AsyncOperationHandles[assetReference].IsDone)
                {
                    SpawnObjectFromLoadedReference(assetReference, transform.position);
                }
                else
                {
                    EnqueueSpawnForAfterInitialization(assetReference);
                }

                return;
            }

            LoadAndSpawn(assetReference);
        }

        private void LoadAndSpawn(AssetReferenceGameObject assetReference)
        {
            AsyncOperationHandle<GameObject> op = Addressables.LoadAssetAsync<GameObject>(assetReference);
            _AsyncOperationHandles[assetReference] = op;
            op.Completed += (operation) =>
            {
                SpawnObjectFromLoadedReference(assetReference, transform.position);
                if (_QueuedSpawnRequests.ContainsKey(assetReference))
                {
                    while (_QueuedSpawnRequests[assetReference]?.Any() == true)
                    {
                        Vector3 position = _QueuedSpawnRequests[assetReference].Dequeue();
                        SpawnObjectFromLoadedReference(assetReference, position);
                    }
                }
            };
        }

        private void EnqueueSpawnForAfterInitialization(AssetReferenceGameObject assetReference)
        {
            if (_QueuedSpawnRequests.ContainsKey(assetReference) == false)
            {
                _QueuedSpawnRequests[assetReference] = new Queue<Vector3>();
            }

            _QueuedSpawnRequests[assetReference].Enqueue(transform.position);
        }

        private void SpawnObjectFromLoadedReference(AssetReferenceGameObject assetReference, Vector3 position)
        {
            assetReference.InstantiateAsync(position, Quaternion.identity).Completed += (asyncOperationHandle) =>
            {
                if (_SpawnedObjects.ContainsKey(assetReference) == false)
                {
                    _SpawnedObjects[assetReference] = new List<GameObject>();
                }
            
                _SpawnedObjects[assetReference].Add(asyncOperationHandle.Result);
                var notify = asyncOperationHandle.Result.AddComponent<NotifyOnDestroy>();
                notify.OnDestroyed += Remove;
                notify.AssetReference = assetReference;
            };
        }

        private void Remove(AssetReferenceGameObject assetReference, NotifyOnDestroy obj)
        {
            Addressables.ReleaseInstance(obj.gameObject);
            _SpawnedObjects[assetReference].Remove(obj.gameObject);
            
            if (_SpawnedObjects[assetReference].Count == 0)
            {
                this.Warning($"Removed all {assetReference.RuntimeKey}");

                if (_AsyncOperationHandles[assetReference].IsValid())
                {
                    Addressables.Release(_AsyncOperationHandles[assetReference]);
                }

                _AsyncOperationHandles.Remove(assetReference);
            }
        }
    }
}