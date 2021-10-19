using System.Collections;
using TalusFramework.Runtime.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.SceneManagement
{
    public class SceneLoader : MonoSingleton<SceneLoader>
    {
        public Coroutine LoadScene(int levelIndex)
        {
            return StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelIndex);
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}
