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

        }

        [Test]
        public void RemoveGameObjects()
        {

        }
    }
}
