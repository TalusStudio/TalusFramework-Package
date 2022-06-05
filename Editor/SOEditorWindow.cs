using UnityEditor;

using Sirenix.OdinInspector.Editor;

using TalusFramework.Managers.Interfaces;
using TalusFramework.Collections.Interfaces;
using TalusFramework.Events;
using TalusFramework.Utility.Logging;

namespace TalusTemplate.Editor
{
    public class SOEditorWindow : OdinMenuEditorWindow
    {
#if ENABLE_BACKEND
        private const string _facebookSettingsPath = "Resources/FacebookSettings.asset";
        private const string _elephantSettingsPath = "Resources/ElephantSettings.asset";
#endif

        [MenuItem("TalusKit/SO Editor %m", false, -9000)]
        private static void OpenWindow()
        {
            var window = GetWindow<SOEditorWindow>();
            window.minSize = new UnityEngine.Vector2(800, 600);
            window.Show();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(false);
            tree.Config.DrawSearchToolbar = true;

            tree.AddAllAssetsAtPath("Managers", "Assets/", typeof(IInitializable), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();

            tree.AddAllAssetsAtPath("Collections", "Assets/", typeof(ICollection), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();

            tree.AddAllAssetsAtPath("Events", "Assets/", typeof(GameEvent), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();

            tree.AddAllAssetsAtPath("Debugging", "Assets/", typeof(Logger), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();

#if ENABLE_BACKEND
            tree.AddAssetAtPath("Backend/Facebook Settings", _facebookSettingsPath, typeof(UnityEngine.ScriptableObject))
                .AddThumbnailIcons();

            tree.AddAssetAtPath("Backend/Elephant Settings", _elephantSettingsPath, typeof(UnityEngine.ScriptableObject))
                .AddThumbnailIcons();
#else
            tree.Add("Backend (not activated)", null);
#endif

            return tree;
        }
    }
}
