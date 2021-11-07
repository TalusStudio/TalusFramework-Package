using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

using QFSW.QC;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.SceneManagement
{
	[HideMonoScript]
	[CommandPrefix("talus.")]
    public class SceneLoaderSO : BaseSO
	{
		private void OnEnable() => QuantumRegistry.RegisterObject(this);
		private void OnDisable() => QuantumRegistry.DeregisterObject(this);

		[Button]
		[DisableInEditorMode]
		public async void LoadLevel(IntVariableSO sceneIndex)
		{
			await LoadScene(sceneIndex.RuntimeValue);
		}

		[Command("load-scene", "loads a scene by name into the game")]
		private static async Task LoadScene(int sceneIndex, LoadSceneMode loadMode = LoadSceneMode.Single)
		{
			// wait one frame
			await Task.Yield();

			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, loadMode);
			await AsyncUtility.PollUntilAsync(16, () => asyncOperation.isDone);
		}
	}
}
