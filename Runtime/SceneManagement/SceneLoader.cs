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
    [CreateAssetMenu(fileName = "New Scene Loader", menuName = "Others/Scene Loader", order = 1)]
    public class SceneLoader : BaseSO
    {
        [Button, DisableInEditorMode]
        public async void LoadLevel(StringVariable scene)
        {
            this.Assert(scene.RuntimeValue != string.Empty, "There is an invalid scene reference!");

            await LoadScene(scene.RuntimeValue);
        }

        [Button, DisableInEditorMode]
        public async void RestartLevel()
        {
            await LoadScene(SceneManager.GetActiveScene().name);
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