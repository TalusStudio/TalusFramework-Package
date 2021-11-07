using System.Linq;

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;

using UnityEditor;

using UnityEngine;

namespace TalusFramework.Editor.Utility.TalusKit
{
	public class MenuEditor : OdinMenuEditorWindow
	{
		private const string TALUS_PERSISTENT_SO_DIR_PATH = "ScriptableObjects/Persistent";

#if ENABLE_BACKEND
        private const string FACEBOOK_SETTINGS_SO_PATH = "FacebookSDK/SDK/Resources/FacebookSettings.asset";
        private const string ELEPHANT_SETTINGS_SO_PATH = "Resources/ElephantSettings.asset";
#endif

		private const string LIGHTING_SETTINGS_DIR_PATH = "ScriptableObjects/Polishing";

		[MenuItem("TalusKit/Menu Editor %m")]
		private static void OpenWindow()
		{
			MenuEditor window = GetWindow<MenuEditor>();
			window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
		}

		protected override OdinMenuTree BuildMenuTree()
		{
			OdinMenuTree tree = new OdinMenuTree(false)
			{
				{
					"Player Settings", Resources.FindObjectsOfTypeAll<PlayerSettings>().FirstOrDefault(),
					EditorIcons.SettingsCog
				}
			};

			tree.AddAllAssetsAtPath("Persistent SO", TALUS_PERSISTENT_SO_DIR_PATH, typeof(ScriptableObject), true)
					.AddThumbnailIcons();

#if ENABLE_BACKEND
            tree.AddAssetAtPath("Facebook Settings", FACEBOOK_SETTINGS_SO_PATH, typeof(ScriptableObject))
                .AddThumbnailIcons();

            tree.AddAssetAtPath("Elephant Settings",  ELEPHANT_SETTINGS_SO_PATH, typeof(ScriptableObject))
                .AddThumbnailIcons();
#endif

			tree.AddAllAssetsAtPath("Lighting Settings", LIGHTING_SETTINGS_DIR_PATH, typeof(ScriptableObject), true)
					.AddThumbnailIcons();

			tree.Config.DrawSearchToolbar = true;
			tree.SortMenuItemsByName();

			return tree;
		}
	}
}
