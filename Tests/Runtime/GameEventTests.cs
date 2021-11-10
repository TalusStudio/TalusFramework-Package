using System.Collections;

using NUnit.Framework;

using TalusFramework.Runtime.Events;

using UnityEngine;
using UnityEngine.TestTools;

namespace TalusFramework.Tests.Runtime
{
	public class GameEventTests
	{
		private GameEventListener _AddTestListenerRef;
		private GameEvent _EventRef;
		private GameEventListener _InitialListenerRef;

		[UnitySetUp]
		public IEnumerator SetUp()
		{
			yield return new EnterPlayMode();

			Debug.Log("Test preparing...");

			// prepare test
			_EventRef = ScriptableObject.CreateInstance<GameEvent>();

			_InitialListenerRef = new GameObject("Test Event Listener", typeof(GameEventListener))
					.GetComponent<GameEventListener>();

			_EventRef.AddListener(_InitialListenerRef);
			_InitialListenerRef.GameEvent = _EventRef;

			LogAssert.ignoreFailingMessages = true;
			LogAssert.Expect(LogType.Error, "GameEvent reference is null!");
		}

		[UnityTearDown]
		public IEnumerator TearDown()
		{
			yield return new ExitPlayMode();

			Object.Destroy(_EventRef);
			Object.Destroy(_InitialListenerRef);

			LogAssert.ignoreFailingMessages = false;
		}

		[UnityTest]
		public IEnumerator AddListenerPasses()
		{
			int currentListenerCount = _EventRef.ListenersCount;

			_EventRef.AddListener(_AddTestListenerRef);

			yield return null;

			Assert.AreEqual(_EventRef.ListenersCount, currentListenerCount + 1);
		}

		[UnityTest]
		public IEnumerator RemoveListenerPasses()
		{
			int currentListenerCount = _EventRef.ListenersCount;

			_EventRef.AddListener(_AddTestListenerRef);

			yield return null;

			Assert.AreEqual(_EventRef.ListenersCount, ++currentListenerCount);
			_EventRef.RemoveListener(_InitialListenerRef);

			yield return null;

			Assert.AreEqual(_EventRef.ListenersCount, --currentListenerCount);
		}

		[UnityTest]
		public IEnumerator RaisePasses()
		{
			yield return null;
		}
	}
}
