using UnityEditor;
using UnityEngine;

using TalusFramework.References.Interfaces;

namespace TalusFramework.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(BaseReference))]
    internal class BaseReferenceDrawer : PropertyDrawer
    {
        private readonly string[] _PopupOptions = { "Use Variable", "Use Constant" };
        private GUIStyle _PopupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_PopupStyle == null)
            {
                _PopupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _PopupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            //
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            //
            SerializedProperty useConstant = property.FindPropertyRelative("UseConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("ConstantValue");
            SerializedProperty variableValue = property.FindPropertyRelative("Variable");

            label = EditorGUI.BeginProperty(position, label, property);
            {
                position = EditorGUI.PrefixLabel(position, label);

                EditorGUI.BeginChangeCheck();

                // Calculate rect for configuration button
                var popupRect = new Rect(position);
                popupRect.yMin += _PopupStyle.margin.top;
                popupRect.width = _PopupStyle.fixedWidth + _PopupStyle.margin.right;
                popupRect.height = _PopupStyle.fixedHeight + _PopupStyle.margin.top;
                position.xMin = popupRect.xMax;

                int index = EditorGUI.Popup(popupRect, useConstant.boolValue ? 1 : 0, _PopupOptions, _PopupStyle);
                useConstant.boolValue = index == 1;

                EditorGUI.PropertyField(position, useConstant.boolValue ? constantValue : variableValue, GUIContent.none);

                if (EditorGUI.EndChangeCheck())
                {
                    if (property.serializedObject.hasModifiedProperties)
                    {
                        property.serializedObject.ApplyModifiedProperties();
                    }
                }

                EditorGUI.indentLevel = indent;
            }
            EditorGUI.EndProperty();
        }
    }
}
