#if ENABLE_COMMANDS
using System.Collections.Generic;
using System.Linq;

using QFSW.QC;

using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.Utility.Commands
{
	[CommandPrefix(".talus")]
    public static class SceneCommands
    {
		private static IEnumerable<Scene> GetScenesInBuild()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            for (int i = 0; i < sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneByBuildIndex(i);
                yield return scene;
            }
        }

        [Command("all-scenes", "gets the name and index of every scene included in the build")]
        private static Dictionary<int, string> GetAllScenes()
        {
            Dictionary<int, string> sceneData = new Dictionary<int, string>();
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            for (int i = 0; i < sceneCount; i++)
            {
                int sceneIndex = i;
                string scenePath = SceneUtility.GetScenePathByBuildIndex(sceneIndex);
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

                sceneData.Add(sceneIndex, sceneName);
            }

            return sceneData;
        }

        [Command("loaded-scenes", "gets the name and index of every scene currently loaded")]
        private static Dictionary<int, string> GetLoadedScenes()
        {
            IEnumerable<Scene> loadedScenes = GetScenesInBuild().Where(x => x.isLoaded);
            Dictionary<int, string> sceneData = loadedScenes.ToDictionary(x => x.buildIndex, x => x.name);
            return sceneData;
        }

        [Command("active-scene", "gets the name of the active primary scene")]
        private static string GetCurrentScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            return scene.name;
        }
	}
}
#endif
