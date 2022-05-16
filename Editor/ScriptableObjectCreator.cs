using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using UnityEditor;
using UnityEngine;

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;

namespace TalusFramework.Editor
{
    public class ScriptableObjectCreator : OdinMenuEditorWindow
    {
        private const string NAMESPACE_NAME = "Talus";

        private static readonly HashSet<Type> _ScriptableObjectTypes = new HashSet<Type>(AssemblyUtilities
                .GetTypes(AssemblyTypeFlags.CustomTypes)
                .Where(t => t.IsClass &&
                    typeof(ScriptableObject).IsAssignableFrom(t) &&
                    !typeof(EditorWindow).IsAssignableFrom(t) &&
                    !typeof(UnityEditor.Editor).IsAssignableFrom(t))
                .Where(t => t.Assembly.GetName().Name.Contains(NAMESPACE_NAME))
                .Where(t => !t.Assembly.GetName().Name.Contains("Editor"))
                .OrderBy(t => t.Namespace));

        private string _CurrentPath;
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

        private void UpdatePath()
        {
            if (!TryGetActiveFolderPath(out _CurrentPath))
            {
                _CurrentPath = "Assets/";
            }
        }

        private static bool TryGetActiveFolderPath(out string path)
        {
            MethodInfo tryGetActiveFolderPath = typeof(ProjectWindowUtil).GetMethod("TryGetActiveFolderPath",
                BindingFlags.Static | BindingFlags.NonPublic);

            object[] args = { null };
            bool found = (bool) tryGetActiveFolderPath.Invoke(null, args);
            path = (string) args[0];
            path = path.Trim('/');
            return found;
        }

        [MenuItem("TalusKit/Create Scriptable Object %l", false, -8000)]
        private static void ShowDialog()
        {
            if (!TryGetActiveFolderPath(out string path))
            {
                path = "Assets/";
            }

            var window = CreateInstance<ScriptableObjectCreator>();
            window.titleContent = new GUIContent("Folder: " + path);
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

        private void PopulatePreviewObject(Type type)
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

        private void CreateAsset(Type nextType)
        {
            string destination = _CurrentPath + "/New " + nextType.Name + ".asset";
            destination = AssetDatabase.GenerateUniqueAssetPath(destination);
            AssetDatabase.CreateAsset(_PreviewObject, destination);
            AssetDatabase.Refresh();
            Selection.activeObject = _PreviewObject;
            //EditorApplication.delayCall += Close;
        }

        private class ScriptableObjectCreatorMenuItem : OdinMenuItem
        {
            private readonly ScriptableObjectCreator _Creator;
            private readonly Type _Type;

            public ScriptableObjectCreatorMenuItem(OdinMenuTree tree, Type type, ScriptableObjectCreator creator) : base(tree, type.Name, type)
            {
                _Type = type;
                _Creator = creator;
            }

            public override string SmartName
            {
                get
                {
                    string[] split = Regex.Split(_Type.Name, @"(?<!^)(?=[A-Z])");
                    return split.Where(t1 => t1.Length > 1).Aggregate("", (current, t1) => current + (t1 + " "));
                }
            }

            protected override void OnDrawMenuItem(Rect rect, Rect labelRect)
            {
                if (SirenixEditorGUI.IconButton(labelRect.AlignMiddle(18).AlignRight(65), EditorIcons.Plus))
                {
                    _Creator.UpdatePath();
                    _Creator.PopulatePreviewObject(_Type);
                    _Creator.CreateAsset(_Type);
                }
            }
        }
    }
}