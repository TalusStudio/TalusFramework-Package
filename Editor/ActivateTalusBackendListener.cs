using System.Collections.Generic;

using TalusFramework.Editor.Utility;
using TalusFramework.Runtime.Utility.Logging;

using UnityEditor;

namespace TalusFramework.Editor
{
    [InitializeOnLoad]
    public class ActivateTalusBackendListener
    {
        // todo: dont forget!
        private const string ELEPHANT_SCENE_PATH = "Assets/Elephant/elephant_scene.unity";
        private const string TALUS_BACKEND_PACKAGE_NAME = "TalusFramework-Backend";

        private const string BACKEND_SUPPORT_KEYWORD = "ENABLE_BACKEND";

        static ActivateTalusBackendListener() => AssetDatabase.importPackageCompleted += OnImportPackageCompleted;

        private static void OnImportPackageCompleted(string packageName)
        {
            // todo: add hash logic
            if (packageName != TALUS_BACKEND_PACKAGE_NAME) { return; }

            TLog.Log("Activating TalusFramework Backend!");

            // activate TalusFramework-Backend symbol
            DefineSymbols.Add(BACKEND_SUPPORT_KEYWORD);

            // add elephant scene to the active scenes.
            List<EditorBuildSettingsScene> editorBuildSettingsScenes =
                    new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

            editorBuildSettingsScenes.Insert(0, new EditorBuildSettingsScene(ELEPHANT_SCENE_PATH, true));
            EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
        }
    }
}
