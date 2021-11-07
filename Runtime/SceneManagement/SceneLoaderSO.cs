﻿using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

#if ENABLE_COMMANDS
using QFSW.QC;
#endif

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.SceneManagement
{
	[HideMonoScript]
#if ENABLE_COMMANDS
	[CommandPrefix("talus.")]
#endif
    public class SceneLoaderSO : BaseSO
	{

#if ENABLE_COMMANDS
		private void OnEnable() => QuantumRegistry.RegisterObject(this);
		private void OnDisable() => QuantumRegistry.DeregisterObject(this);
#endif

		[Button]
		[DisableInEditorMode]
		public async void LoadLevel(IntVariableSO sceneIndex)
		{
			await LoadScene(sceneIndex.RuntimeValue);
		}

#if ENABLE_COMMANDS
		[Command("load-scene", "loads a scene by name into the game")]
#endif
		private static async Task LoadScene(int sceneIndex, LoadSceneMode loadMode = LoadSceneMode.Single)
		{
			// wait one frame
			await Task.Yield();

			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, loadMode);
			await AsyncUtility.PollUntilAsync(16, () => asyncOperation.isDone);
		}
	}
}
