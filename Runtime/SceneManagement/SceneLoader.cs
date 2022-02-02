using System.Threading.Tasks;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility;
using TalusFramework.Runtime.Variables;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.SceneManagement
{
    public class SceneLoader : BaseSO
    {
#region LEVEL_LOADING
        [Button, DisableInEditorMode]
        public static async void LoadLevel(string scene)
        {
            await LoadScene(scene);
        }

        [Button, DisableInEditorMode]
        public async void LoadLevel(StringVariable scene)
        {
            await LoadScene(scene.RuntimeValue);
        }

        [Button, DisableInEditorMode]
        public static async void LoadLevel(int sceneIndex)
        {
            await LoadScene(sceneIndex);
        }

        [Button, DisableInEditorMode]
        public async void LoadLevel(IntVariable sceneIndex)
        {
            await LoadScene(sceneIndex.RuntimeValue);
        }
#endregion

        [Button, DisableInEditorMode]
        public async void RestartLevel()
        {
            await LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private static async Task LoadScene(int sceneIndex, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            // wait one frame.
            await Task.Yield();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, loadMode);
            await AsyncUtility.PollUntilAsync(16, () => asyncOperation.isDone);
        }

        private static async Task LoadScene(string scene, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            // wait one frame.
            await Task.Yield();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene, loadMode);
            await AsyncUtility.PollUntilAsync(16, () => asyncOperation.isDone);
        }
    }
}