using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace TalusFramework.Editor.CodeGenerator
{
    internal class CodeGeneratorWindow : EditorWindow
    {
        /* --------- DEPENDENCY GRAPH ---------*
         * [1] Collection
         * [2] Constant
         * [3] Game Event Listener
         * [4] Game Event
         * [6] Reference
         * [5] Variable
         *
         * /  1  2  3  4  5
         * 1     X        X
         * 2        X
         * 3
         * 4
         * 5
         */

        private readonly bool[,] _dependencyGraph = new bool[CodeGenerator.TYPE_COUNT, CodeGenerator.TYPE_COUNT]
        {
            { false, false, false, false, false, false },
            { false, false, false, false, false, false },
            { false, false, false, true, false, false },
            { false, false, false, false, false, false },
            { false, false, false, false, false, false },
            { false, false, false, false, false, false }
        };

        private readonly bool[] _states = new bool[CodeGenerator.TYPE_COUNT];
        private readonly string[] _names = new string[CodeGenerator.TYPE_COUNT]
        {
            "Collection",
            "Constant",
            "Game Event Listener",
            "Game Event",
            "Reference",
            "Variable"
        };

        private string _typeName;
        private string _namespace;

        private AnimBool _clampedValueHelpBoxAnim;

        [MenuItem("TalusKit/Code Generation", priority = -999999)]
        private static void ShowWindow()
        {
            var window = GetWindow<CodeGeneratorWindow>();
            window.titleContent = new GUIContent("Code Generation");
            window.minSize = new Vector2(300, 350);
        }

        private void OnEnable()
        {
            _clampedValueHelpBoxAnim = new AnimBool();
            _clampedValueHelpBoxAnim.valueChanged.AddListener(Repaint);
        }

        private void OnGUI()
        {
            GUILayout.Space(8);

            TypeSelection();

            EditorGUILayout.Space();

            DataFields();

            if (string.IsNullOrEmpty(_typeName) || string.IsNullOrEmpty(_namespace))
            {
                GUI.enabled = false;
            }

            GUILayout.FlexibleSpace();
            GUI.backgroundColor = Color.green;

            if (GUILayout.Button("Generate", GUILayout.MinHeight(50)))
            {
                CodeGenerator.Data data = new CodeGenerator.Data()
                {
                    Types = _states,
                    TypeName = _typeName,
                    Namespace = _namespace
                };

                CodeGenerator.Generate(data);
                AssetDatabase.Refresh();
            }
        }
        private void TypeSelection()
        {
            Color defaultColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.yellow;
            GUILayout.Label("Select Type(s)", EditorStyles.foldoutHeader);
            GUI.backgroundColor = defaultColor;

            for (int i = 0; i < CodeGenerator.TYPE_COUNT; i++)
            {
                bool isDepending = IsDepending(i);

                if (isDepending)
                {
                    _states[i] = true;
                }

                EditorGUI.BeginDisabledGroup(isDepending);

                _states[i] = EditorGUILayout.Toggle(_names[i], _states[i]);

                EditorGUI.EndDisabledGroup();
            }
        }

        private void DataFields()
        {
            Color defaultColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.yellow;
            GUILayout.Label("Information", EditorStyles.foldoutHeader);
            GUI.backgroundColor = defaultColor;

            _typeName = EditorGUILayout.TextField(new GUIContent("Type Name", "Case sensitive, ensure exact match with actual type name"), _typeName);

            if (string.IsNullOrEmpty(_typeName))
            {
                EditorGUILayout.HelpBox("Please fill out the Type Name", MessageType.Error);
            }

            _namespace = EditorGUILayout.TextField(new GUIContent("Namespace", "Case sensitive, ensure exact match with actual namespace"), _namespace);

            if (string.IsNullOrEmpty(_namespace))
            {
                EditorGUILayout.HelpBox("Please fill out the Namespace", MessageType.Error);
            }
        }

        // Given an index, polls the dependency graph, and returns whether anyone is depending on it
        private bool IsDepending(int index)
        {
            for (int i = 0; i < CodeGenerator.TYPE_COUNT; i++)
            {
                if (_states[i] && _dependencyGraph[i, index])
                    return true;
            }

            return false;
        }
    }
}