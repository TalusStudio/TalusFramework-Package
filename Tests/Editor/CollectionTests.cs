using System.Collections.Generic;

using NUnit.Framework;

using UnityEngine;

using TalusFramework.Collections;

namespace TalusFramework.Tests.Editor
{
    public class CollectionTests
    {
        private GameObjectCollection _Collection;
        private List<GameObject> _Objects;

        [SetUp]
        public void SetUp()
        {
            _Collection = ScriptableObject.CreateInstance<GameObjectCollection>();
            _Objects = new List<GameObject>
            {
                new GameObject("Test GameObject 1"),
                new GameObject("Test GameObject 2"),
                new GameObject("Test GameObject 3")
            };
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_Collection);

            foreach (GameObject obj in _Objects)
            {
                Object.DestroyImmediate(obj);
            }

            _Objects.Clear();
        }

        [Test]
        public void AddGameObjects()
        {
            foreach (GameObject obj in _Objects)
            {
                obj.AddComponent<MeshRenderer>();
                obj.AddComponent<MeshFilter>();

                bool success = _Collection.Add(obj);
                Assert.IsTrue(success);
            }

            Assert.AreEqual(3, _Collection.Count);

            int bits = 0;

            _Collection.Items.ForEach(item =>
            {
                int index = _Objects.IndexOf(item);
                Assert.GreaterOrEqual(index, 0);
                bits |= 1 << index;
            });

            Assert.AreEqual(7, bits);
        }

        [Test]
        public void RemoveGameObjects()
        {
            foreach (GameObject obj in _Objects)
            {
                obj.AddComponent<MeshRenderer>();
                obj.AddComponent<MeshFilter>();

                _Collection.Add(obj);
            }

            int count = 3;

            foreach (GameObject obj in _Objects)
            {
                _Collection.Remove(obj);
                count--;
                Assert.AreEqual(count, _Collection.Count);
            }
        }
    }
}
