using Sirenix.OdinInspector;

using TalusFramework.Runtime.Events;
using TalusFramework.Runtime.Utility.Logging;
using TalusFramework.Runtime.Variables;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.SceneManagement
{
	/// <summary>
	///     invokes LevelLoadEvent
	/// </summary>
	[HideMonoScript]
	public class SceneLoadListener : MonoBehaviour
	{
		[Required]
		[AssetSelector]
		[LabelWidth(110)]
		[SerializeField]
		private GameEvent _LevelLoadEvent;

		[Required]
		[AssetSelector]
		[LabelWidth(110)]
		[SerializeField]
		private IntVariableSO _CurrentLevelIndex;

		private void OnEnable()
		{
			SceneManager.sceneLoaded += HandleSceneLoad;
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded -= HandleSceneLoad;
		}

		private void HandleSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
		{
			TLog.Log("<color=yellow>SceneListener: " + scene.name + " loaded!</color>");

			_CurrentLevelIndex.SetValue(scene.buildIndex);
			_LevelLoadEvent.Raise();
		}
	}
}
