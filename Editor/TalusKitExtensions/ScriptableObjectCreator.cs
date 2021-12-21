using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;

using UnityEditor;

using UnityEngine;

namespace TalusFramework.Editor.TalusKitExtensions
{
    public class ScriptableObjectCreator : OdinMenuEditorWindow
    {
        private const string NAMESPACE_NAME = "Talus";

        private static readonly HashSet<Type> _ScriptableObjectTypes = new HashSet<Type>(AssemblyUtilities
                .GetTypes(AssemblyTypeFlags.CustomTypes)
                .Where(t =>
                        t.IsClass &&
                        typeof(ScriptableObject).IsAssignableFrom(t) &&
                        !typeof(EditorWindow).IsAssignableFrom(t) &&
                        !typeof(UnityEditor.Editor).IsAssignableFrom(t))
                .Where(t =>
                        t.Assembly.GetName().Name.Contains(NAMESPACE_NAME))
                .OrderBy(t => t.Namespace));

        private string _CurrentPath;
        private ScriptableObject _PreviewObject;
        private Vector2 _Scroll;
        private Texture2D[] _Icons;

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
            MethodInfo _tryGetActiveFolderPath = typeof(ProjectWindowUtil).GetMethod("TryGetActiveFolderPath",
                BindingFlags.Static | BindingFlags.NonPublic);

            object[] args = { null };
            bool found = (bool) _tryGetActiveFolderPath.Invoke(null, args);
            path = (string) args[0];
            path = path.Trim('/');
            return found;
        }

        [MenuItem("TalusKit/Create Scriptable Object %t", priority = -1001)]
        //[MenuItem("Assets/Create Scriptable Object %t", priority = -1001)]
        private static void ShowDialog()
        {
            if (!TryGetActiveFolderPath(out string path))
            {
                path = "Assets/";
            }

            var window = CreateInstance<ScriptableObjectCreator>();
            window.ShowUtility();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(600, 500);
            window.titleContent = new GUIContent("Folder: " + path);
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            MenuWidth = 250;
            WindowPadding = Vector4.one * 10f;

            var tree = new OdinMenuTree(false);
            tree.DefaultMenuStyle = OdinMenuStyle.TreeViewStyle;
            tree.Config.DrawSearchToolbar = true;

            foreach (Type type in _ScriptableObjectTypes.ToList())
            {
                if (type == null || type.IsAbstract || type.IsGenericType)
                {
                    continue;
                }

                var customMenuItem = new ScriptableObjectCreatorMenuItem(tree, type, this);
                tree.AddMenuItemAtPath(type.Namespace, customMenuItem).AddThumbnailIcons();
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
            private readonly ScriptableObjectCreator _creator;
            private readonly Type _type;

            public ScriptableObjectCreatorMenuItem(OdinMenuTree tree, Type type, ScriptableObjectCreator creator) :
                    base(tree, type.Name, type)
            {
                _type = type;
                _creator = creator;
            }

            public override string SmartName
            {
                get
                {
                    string[] split = Regex.Split(_type.Name, @"(?<!^)(?=[A-Z])");
                    string formattedClassName = "";

                    for (int i = 0; i < split.Length; ++i)
                    {
                        if (split[i].Length <= 1)
                        {
                            continue;
                        }

                        formattedClassName += split[i] + " ";
                    }

                    return formattedClassName;
                }
            }

            protected override void OnDrawMenuItem(Rect rect, Rect labelRect)
            {
                if (SirenixEditorGUI.IconButton(labelRect.AlignMiddle(18).AlignRight(65), EditorIcons.Plus))
                {
                    _creator.UpdatePath();
                    _creator.PopulatePreviewObject(_type);
                    _creator.CreateAsset(_type);
                }
            }
        }
    }
}