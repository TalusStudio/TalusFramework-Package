using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

using Sirenix.OdinInspector.Editor;

using TalusFramework.Base;
using TalusFramework.Managers.Interfaces;
using TalusFramework.Collections.Interfaces;
using TalusFramework.Events.Interfaces;

namespace TalusFramework.Editor
{
    internal class SOEditorWindow : OdinMenuEditorWindow
    {
        private const string _SOPath = "Assets/Scriptables";

        private readonly Dictionary<System.Type, string> _Types = new Dictionary<System.Type, string>
        {
            { typeof(IInitable), "# Managers" },
            { typeof(ICollection), "# Collections" },
            { typeof(IBaseEvent), "# Events" },
            { typeof(BaseValue), "# Variables" }
        };

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
            var tree = new OdinMenuTree(false);
            tree.Config.DrawSearchToolbar = true;

            foreach (KeyValuePair<System.Type, string> type in _Types)
            {
                tree.AddAllAssetsAtPath(type.Value, _SOPath, type.Key, true, true)
                    .AddThumbnailIcons()
                    .SortMenuItemsByName();
            }

            return tree;
        }
    }
}
