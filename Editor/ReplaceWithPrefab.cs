using UnityEditor;
using UnityEngine;

using TalusFramework.Runtime.Utility.Logging;

namespace TalusFramework.Editor
{
    public class ReplaceWithPrefab : EditorWindow
    {
        [SerializeField]
        private GameObject prefab;

        [MenuItem("TalusKit/Replace With Prefab %q", false, -1000)]
        private static void CreateReplaceWithPrefab()
        {
            GetWindow<ReplaceWithPrefab>().Show();
        }

        private void OnGUI()
        {
            prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false);

            if (GUILayout.Button("Replace"))
            {
                GameObject[] selection = Selection.gameObjects;

                for (int i = selection.Length - 1; i >= 0; --i)
                {
                    GameObject selected = selection[i];
                    GameObject newObject;

                    if (PrefabUtility.IsPartOfPrefabAsset(prefab))
                    {
                        newObject = (GameObject) PrefabUtility.InstantiatePrefab(prefab);
                    }
                    else
                    {
                        newObject = Instantiate(prefab);
                        newObject.name = prefab.name;
                    }

                    if (newObject == null)
                    {
                        TLog.Log("Error instantiating prefab!", LogType.Error);
                        break;
                    }

                    Undo.RegisterCreatedObjectUndo(newObject, "Replace With Prefabs");
                    newObject.transform.parent = selected.transform.parent;
                    newObject.transform.localPosition = selected.transform.localPosition;
                    newObject.transform.localRotation = selected.transform.localRotation;
                    newObject.transform.localScale = selected.transform.localScale;
                    newObject.transform.SetSiblingIndex(selected.transform.GetSiblingIndex());
                    Undo.DestroyObjectImmediate(selected);
                }
            }

            GUI.enabled = false;
            EditorGUILayout.LabelField("Selection count: " + Selection.objects.Length);
        }
    }
}
