using UnityEditor;

using Sirenix.OdinInspector.Editor;

using TalusFramework.Managers.Interfaces;
using TalusFramework.Collections.Interfaces;
using TalusFramework.Events;

namespace TalusTemplate.Editor
{
    public class ScriptableObjectEditorWindow : OdinMenuEditorWindow
    {
        private const string _SOPath = "Assets/ScriptableObjects";

#if ENABLE_BACKEND
        private const string _FacebookSettingsPath = "Resources/FacebookSettings.asset";
        private const string _ElephantSettingsPath = "Resources/ElephantSettings.asset";
#endif

        [MenuItem("TalusKit/SO Editor %m", false, -9000)]
        private static void OpenWindow()
        {
            var window = GetWindow<ScriptableObjectEditorWindow>();
            window.minSize = new UnityEngine.Vector2(800, 600);
            window.Show();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(false);
            tree.Config.DrawSearchToolbar = true;

            tree.AddAllAssetsAtPath("# Managers", _SOPath, typeof(IInitializable), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();

            tree.AddAllAssetsAtPath("# Collections", _SOPath, typeof(ICollection), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();

            tree.AddAllAssetsAtPath("# Events", _SOPath, typeof(GameEvent), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();

#if ENABLE_BACKEND
            tree.AddAssetAtPath("# Backend/Facebook Settings", _FacebookSettingsPath, typeof(UnityEngine.ScriptableObject))
                .AddThumbnailIcons();

            tree.AddAssetAtPath("# Backend/Elephant Settings", _ElephantSettingsPath, typeof(UnityEngine.ScriptableObject))
                .AddThumbnailIcons();
#else
            tree.Add("# Backend (not active)/Facebook Settings", null);
            tree.Add("# Backend (not active)/Elephant Settings", null);
#endif

            return tree;
        }
    }
}
