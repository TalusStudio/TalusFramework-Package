using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using UnityEditor;
using UnityEngine;

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;

namespace TalusFramework.Editor
{
    internal class ScriptableObjectCreator : OdinMenuEditorWindow
    {
        private const string _NamespaceName = "Talus";

        private static readonly HashSet<Type> _ScriptableObjectTypes = new HashSet<Type>(AssemblyUtilities
                .GetTypes(AssemblyTypeFlags.CustomTypes)
                .Where(t => t.IsClass &&
                    typeof(ScriptableObject).IsAssignableFrom(t) &&
                    !typeof(EditorWindow).IsAssignableFrom(t) &&
                    !typeof(UnityEditor.Editor).IsAssignableFrom(t))
                .Where(t => t.Assembly.GetName().Name.Contains(_NamespaceName))
                .Where(t => !t.Assembly.GetName().Name.Contains("Editor"))
                .OrderBy(t => t.Namespace));

        private static string _CurrentPath;
        private ScriptableObject _PreviewObject;
        private Vector2 _Scroll;

        private Type SelectedType
        {
            get
            {
                OdinMenuItem m = MenuTree.Selection.LastOrDefault();
                return m == null ? null : m.Value as Type;
            }
        }

        [MenuItem("TalusKit/SO Creator %l", false, -8000)]
        private static void ShowDialog()
        {
            UpdatePath();

            var window = CreateInstance<ScriptableObjectCreator>();
            window.titleContent = new GUIContent("Folder:" + _CurrentPath);
            window.ShowUtility();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            MenuWidth = 250;
            WindowPadding = Vector4.one * 10f;

            var tree = new OdinMenuTree(false)
            {
                DefaultMenuStyle = OdinMenuStyle.TreeViewStyle,
                Config = { DrawSearchToolbar = true }
            };

            foreach (Type type in _ScriptableObjectTypes.ToList())
            {
                if (type == null || type.Namespace == null || type.IsAbstract || type.IsGenericType)
                {
                    continue;
                }

                var customMenuItem = new ScriptableObjectCreatorMenuItem(tree, type, this);

                // type.Namespace => TalusFramework.RunTime.Variables etc.
                string[] splittedNamespaceName = type.Namespace.Split('.');
                tree.AddMenuItemAtPath(splittedNamespaceName[splittedNamespaceName.Length - 1], customMenuItem).AddThumbnailIcons();
            }

            tree.Selection.SelectionChanged += e =>
            {
                if (_PreviewObject && !AssetDatabase.Contains(_PreviewObject))
                {
                    DestroyImmediate(_PreviewObject);
                }

                if (e != SelectionChangedType.ItemAdded)
                {
                    return;
                }

                _PreviewObject = CreateInstance(SelectedType);
            };

            return tree;
        }

        public void PopulatePreviewObject(Type type)
        {
            if (_PreviewObject != null && !AssetDatabase.Contains(_PreviewObject))
            {
                DestroyImmediate(_PreviewObject);
                _PreviewObject = CreateInstance(type);
            }

            if (_PreviewObject == null)
            {
                _PreviewObject = CreateInstance(type);
            }
        }

        protected override IEnumerable<object> GetTargets()
        {
            yield return _PreviewObject;
        }

        protected override void DrawEditor(int index)
        {
            _Scroll = GUILayout.BeginScrollView(_Scroll);

            {
                base.DrawEditor(index);
            }

            GUILayout.EndScrollView();
        }

        public void CreateAsset(Type type)
        {
            UpdatePath();

            string destination = _CurrentPath + "/New " + type.Name + ".asset";
            destination = AssetDatabase.GenerateUniqueAssetPath(destination);
            AssetDatabase.CreateAsset(_PreviewObject, destination);
            AssetDatabase.Refresh();
            Selection.activeObject = _PreviewObject;
            //EditorApplication.delayCall += Close;
        }

        private static void UpdatePath()
        {
            if (!TryGetActiveFolderPath(out _CurrentPath))
            {
                _CurrentPath = "Assets/";
            }
        }

        private static bool TryGetActiveFolderPath(out string path)
        {
            MethodInfo tryGetActiveFolderPath = typeof(ProjectWindowUtil)
                .GetMethod("TryGetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);

            object[] args = { null };
            bool found = (bool) tryGetActiveFolderPath.Invoke(null, args);
            path = (string) args[0];
            path = path.Trim('/');
            return found;
        }
    }
}