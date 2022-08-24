using UnityEditor;
using UnityEngine;

using Sirenix.OdinInspector.Editor;

using TalusFramework.Base;
using TalusFramework.Managers.Interfaces;
using TalusFramework.Collections.Interfaces;
using TalusFramework.Events.Interfaces;

#if ENABLE_BACKEND
using Facebook.Unity.Settings;
#endif

namespace TalusFramework.Editor
{
    internal class SOEditorWindow : OdinMenuEditorWindow
    {
        [MenuItem("TalusKit/SO Editor %m", priority = 21)]
        private static void OpenWindow()
        {
            var window = GetWindow<SOEditorWindow>();
            window.titleContent = new GUIContent("SO Editor");
            window.minSize = new Vector2(800, 600);
            window.Show();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var soPath = "Assets/Scriptables";

            var tree = new OdinMenuTree(false);
            tree.Config.DrawSearchToolbar = true;
            tree.AddAllAssetsAtPath("# Managers", soPath, typeof(IInitable), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();
            tree.AddAllAssetsAtPath("# Collections", soPath, typeof(ICollection), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();
            tree.AddAllAssetsAtPath("# Events", soPath, typeof(IBaseEvent), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();
            tree.AddAllAssetsAtPath(" # Variables", soPath, typeof(BaseValue), true, true)
                .AddThumbnailIcons()
                .SortMenuItemsByName();

#if ENABLE_BACKEND
            tree.AddAssetAtPath(
                "# Backend/Facebook Settings",
                AssetDatabase.GetAssetPath(FacebookSettings.Instance),
                typeof(ScriptableObject)
            ).AddThumbnailIcons();
#else
            tree.Add("# Backend (not active)/Facebook Settings", null);
            tree.Add("# Backend (not active)/GA Settings", null);
#endif

            return tree;
        }
    }
}
