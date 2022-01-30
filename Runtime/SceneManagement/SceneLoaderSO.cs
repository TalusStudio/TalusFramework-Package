using System.Threading.Tasks;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility;
using TalusFramework.Runtime.Variables;

using UnityEngine;
using UnityEngine.SceneManagement;
#if ENABLE_COMMANDS
using QFSW.QC;
#endif

namespace TalusFramework.Runtime.SceneManagement
{
#if ENABLE_COMMANDS
    [CommandPrefix("talus.")]
#endif
    public class SceneLoaderSO : BaseSO
    {
#region Level Load
        [Button, DisableInEditorMode]
        public static async void LoadLevel(string scene)
        {
            await LoadScene(scene);
        }

        [Button, DisableInEditorMode]
        public async void LoadLevel(StringVariableSO scene)
        {
            await LoadScene(scene.RuntimeValue);
        }

        [Button, DisableInEditorMode]
        public static async void LoadLevel(int sceneIndex)
        {
            await LoadScene(sceneIndex);
        }

        [Button, DisableInEditorMode]
        public async void LoadLevel(IntVariableSO sceneIndex)
        {
            await LoadScene(sceneIndex.RuntimeValue);
        }
#endregion

        [Button, DisableInEditorMode]
        public async void RestartLevel()
        {
            await LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


#if ENABLE_COMMANDS
        [Command("load-scene", "loads a scene by index into the game")]
#endif
        private static async Task LoadScene(int sceneIndex, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            // wait one frame.
            await Task.Yield();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, loadMode);
            await AsyncUtility.PollUntilAsync(16, () => asyncOperation.isDone);
        }

#if ENABLE_COMMANDS
        [Command("load-scene", "loads a scene by index into the game")]
#endif
        private static async Task LoadScene(string scene, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            // wait one frame.
            await Task.Yield();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene, loadMode);
            await AsyncUtility.PollUntilAsync(16, () => asyncOperation.isDone);
        }

#if ENABLE_COMMANDS
        private void OnEnable() => QuantumRegistry.RegisterObject(this);
        private void OnDisable() => QuantumRegistry.DeregisterObject(this);
#endif
    }
}