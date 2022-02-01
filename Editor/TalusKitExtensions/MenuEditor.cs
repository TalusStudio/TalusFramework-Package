using System.Linq;

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;

using UnityEditor;

using UnityEngine;

namespace TalusFramework.Editor.TalusKitExtensions
{
    public class MenuEditor : OdinMenuEditorWindow
    {
        private const string TALUS_PERSISTENT_SO_DIR_PATH = "ScriptableObjects/Template_Persistent";

#if ENABLE_BACKEND
        private const string FACEBOOK_SETTINGS_SO_PATH = "FacebookSDK/SDK/Resources/FacebookSettings.asset";
        private const string ELEPHANT_SETTINGS_SO_PATH = "Resources/ElephantSettings.asset";
#endif

        private const string LIGHTING_SETTINGS_DIR_PATH = "ScriptableObjects/Template_Polishing";

        [MenuItem("TalusKit/Menu Editor %m", priority = -1000)]
        private static void OpenWindow()
        {
            var window = GetWindow<MenuEditor>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(false);

            tree.Add("1_Player Settings", Resources.FindObjectsOfTypeAll<PlayerSettings>().FirstOrDefault());

            tree.AddAllAssetsAtPath("2_Scriptable Objects", TALUS_PERSISTENT_SO_DIR_PATH, typeof(ScriptableObject), true)
                .AddThumbnailIcons();

#if ENABLE_BACKEND
            tree.AddAssetAtPath("Facebook Settings", FACEBOOK_SETTINGS_SO_PATH, typeof(ScriptableObject))
                .AddThumbnailIcons();

            tree.AddAssetAtPath("Elephant Settings",  ELEPHANT_SETTINGS_SO_PATH, typeof(ScriptableObject))
                .AddThumbnailIcons();
#endif

            tree.AddAllAssetsAtPath("3_Polishing", LIGHTING_SETTINGS_DIR_PATH, typeof(ScriptableObject), true)
                .AddThumbnailIcons();

            tree.Config.DrawSearchToolbar = true;
            tree.SortMenuItemsByName();

            return tree;
        }
    }
}