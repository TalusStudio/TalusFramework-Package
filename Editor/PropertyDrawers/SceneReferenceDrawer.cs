using UnityEditor;
using UnityEngine;

using TalusFramework.Utility;

namespace TalusFramework.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SceneReference))]
    [CanEditMultipleObjects]
    internal class SceneReferenceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var isDirtyProperty = property.FindPropertyRelative("m_IsDirty");
            if (isDirtyProperty.boolValue)
            {
                // This will force change in the property and make it dirty.
                // After the user saves, he'll actually see the changed changes and commit them.
                isDirtyProperty.boolValue = false;
            }

            EditorGUI.BeginProperty(position, label, property);
            {
                position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

                var sceneAssetProperty = property.FindPropertyRelative("m_SceneAsset");
                bool hadReference = sceneAssetProperty.objectReferenceValue != null;

                EditorGUI.PropertyField(position, sceneAssetProperty, new GUIContent());

                if (sceneAssetProperty.objectReferenceValue == null && hadReference)
                {
                    property.FindPropertyRelative("m_ScenePath").stringValue = string.Empty;
                }
            }

            EditorGUI.EndProperty();
        }
    }
}