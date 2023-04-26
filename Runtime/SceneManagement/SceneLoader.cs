using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Utility;
using TalusFramework.Utility.Assertions;
using TalusFramework.Variables;

namespace TalusFramework.SceneManagement
{
    [CreateAssetMenu(fileName = "New Scene Loader", menuName = "Talus/Framework/Scene Loader", order = 1)]
    public class SceneLoader : BaseSO
    {
        [Button, DisableInEditorMode]
        public async void LoadLevel(IntVariable scene)
        {
            await LoadScene(scene.RuntimeValue);
        }
        
        [Button, DisableInEditorMode]
        public async void LoadLevel(int sceneIndex)
        {
            await LoadScene(sceneIndex);
        }

        [Button, DisableInEditorMode]
        public async void LoadLevel(SceneVariable scene)
        {
            this.Assert(!scene.RuntimeValue.IsEmpty, "There is an invalid scene reference!");

            await LoadScene(scene.RuntimeValue.ScenePath);
        }

        [Button, DisableInEditorMode]
        public async void LoadLevel(SceneReference scene)
        {
            this.Assert(!scene.IsEmpty, "There is an invalid scene reference!");

            await LoadScene(scene.ScenePath);
        }

        [Button, DisableInEditorMode]
        public async void RestartLevel()
        {
            await LoadScene(SceneManager.GetActiveScene().name);
        }

        private static async Task LoadScene(string sceneName, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            // wait one frame.
            await Task.Yield();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadMode);
            asyncOperation.allowSceneActivation = false;

            await AsyncUtility.PollUntilAsync(16, () => asyncOperation.progress >= 0.9f);

            asyncOperation.allowSceneActivation = true;
        }

        private static async Task LoadScene(int sceneIndex, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            // wait one frame.
            await Task.Yield();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, loadMode);
            asyncOperation.allowSceneActivation = false;

            await AsyncUtility.PollUntilAsync(16, () => asyncOperation.progress >= 0.9f);

            asyncOperation.allowSceneActivation = true;
        }
    }
}
