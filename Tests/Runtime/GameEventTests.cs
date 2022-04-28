using System.Collections;

using UnityEngine;
using UnityEngine.TestTools;

using NUnit.Framework;

using TalusFramework.Runtime.Events;

namespace TalusFramework.Tests.Runtime
{
    public class GameEventTests
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            yield return new EnterPlayMode();

            Debug.Log("Test preparing...");
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            yield return new ExitPlayMode();
        }

        [UnityTest]
        public IEnumerator AddListenerPasses()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator RemoveListenerPasses()
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator RaisePasses()
        {
            yield return null;
        }
    }
}