using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;

namespace TalusFramework.Editor.CodeGenerator
{
    /// <summary>
    ///     imported : https://github.com/DanielEverland/ScriptableObject-Architecture
    /// </summary>
    public static class CodeGenerator
    {
        private const string _DefaultTemplatesPath = "Packages/com.talus.talusframework/Editor/CodeGenerator/Templates";
        private const string _TargetFolderName = "Scripts/GENERATED_CLASS";

        static CodeGenerator()
        {
            CreateTargetDirectories();
            GatherFilePaths();
        }

        private static void CreateTargetDirectories()
        {
            _targetDirectories = new string[TYPE_COUNT]
            {
                Application.dataPath + "/" + _TargetFolderName + "/Collections",
                Application.dataPath + "/" + _TargetFolderName + "/Constants",
                Application.dataPath + "/" + _TargetFolderName + "/Events",
                Application.dataPath + "/" + _TargetFolderName + "/Events",
                Application.dataPath + "/" + _TargetFolderName + "/References",
                Application.dataPath + "/" + _TargetFolderName + "/Variables"
            };
        }

        private static void GatherFilePaths()
        {
            string assetPath = _DefaultTemplatesPath;
            string folderToStartSearch = Directory.GetParent(assetPath).FullName;

            Queue<string> foldersToCheck = new Queue<string>();
            foldersToCheck.Enqueue(folderToStartSearch);

            while (foldersToCheck.Count > 0)
            {
                string currentDirectory = foldersToCheck.Dequeue();

                foreach (string filePath in Directory.GetFiles(currentDirectory))
                {
                    string fileName = Path.GetFileName(filePath);

                    for (int i = 0; i < TYPE_COUNT; i++)
                    {
                        if (_templateNames[i] == fileName)
                        {
                            _templatePaths[i] = filePath;
                        }
                    }
                }
                foreach (string subDirectory in Directory.GetDirectories(currentDirectory))
                {
                    foldersToCheck.Enqueue(subDirectory);
                }
            }

            // Double check that all filepaths were found
            for (int i = 0; i < TYPE_COUNT; i++)
            {
                if (_templatePaths[i] == default(string))
                {
                    Debug.LogError("Couldn't find path for " + _templatePaths[i]);
                }
            }
        }

        public const int TYPE_COUNT = 6;

        public struct Data
        {
            public bool[] Types;
            public string TypeName;
            public string Namespace;
        }

        private static string[] _templateNames = new string[TYPE_COUNT]
        {
            "CollectionTemplate",
            "ConstantTemplate",
            "GameEventListenerTemplate",
            "GameEventTemplate",
            "ReferenceTemplate",
            "VariableTemplate",
        };

        private static string[] _targetFileNames = new string[TYPE_COUNT]
        {
            "{0}Collection.cs",
            "{0}Constant.cs",
            "{0}GameEventListener.cs",
            "{0}GameEvent.cs",
            "{0}Reference.cs",
            "{0}Variable.cs",
        };

        private static string[] _targetDirectories = null;
        private static string[] _templatePaths = new string[TYPE_COUNT];
        private static string[,] _replacementStrings = null;

        private static string TypeName { get { return _replacementStrings[1, 1]; } }

        public static void Generate(Data data)
        {
            _replacementStrings = new string[3, 2]
            {
                { "$TYPE$", data.TypeName },
                { "$TYPE_NAME$", CapitalizeFirstLetter(data.TypeName) },
                { "$NAMESPACE$", data.Namespace }
            };

            for (int i = 0; i < TYPE_COUNT; i++)
            {
                if (data.Types[i])
                {
                    GenerateScript(i);
                }
            }
        }
        private static void GenerateScript(int index)
        {
            string targetFilePath = GetTargetFilePath(index);
            string contents = GetScriptContents(index);

            if (File.Exists(targetFilePath))
            {
                Debug.Log("Cannot create file at " + targetFilePath + " because a file already exists, and overwrites are disabled");
                return;
            }

            Debug.Log("Creating..." + targetFilePath);

            Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath));
            File.WriteAllText(targetFilePath, contents);
        }

        private static string GetScriptContents(int index)
        {
            string templatePath = _templatePaths[index];
            string templateContent = File.ReadAllText(templatePath);

            string output = templateContent;

            for (int i = 0; i < _replacementStrings.GetLength(0); i++)
            {
                output = output.Replace(_replacementStrings[i, 0], _replacementStrings[i, 1]);
            }

            return output;
        }

        private static string GetTargetFilePath(int index)
        {
            return _targetDirectories[index] + "/" + string.Format(_targetFileNames[index], TypeName);
        }

        private static string CapitalizeFirstLetter(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}