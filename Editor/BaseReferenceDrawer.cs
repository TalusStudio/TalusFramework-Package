using UnityEditor;
using UnityEngine;

using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Editor
{
    [CustomPropertyDrawer(typeof(BaseReference))]
    public class BaseReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] popupOptions =
        {
            "Use Plain",
            "Use Constant",
            "Use Variable"
        };
        
        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
                {
                    imagePosition = ImagePosition.ImageOnly
                };
            }

            // Get condition properties
            SerializedProperty usePlain = property.FindPropertyRelative("UsePlain");
            SerializedProperty useConstant = property.FindPropertyRelative("UseConstant");

            // Get values
            SerializedProperty plainValue = property.FindPropertyRelative("PlainValue");
            SerializedProperty constantValue = property.FindPropertyRelative("ConstantValue");
            SerializedProperty variableValue = property.FindPropertyRelative("Variable");

            label = EditorGUI.BeginProperty(position, label, property);
            //todo: refactor comment
            //label.text += "(" + (useConstant.boolValue ? "Const" : "Variable") + ")";
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            buttonRect.height = popupStyle.fixedHeight + popupStyle.margin.top;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            int _index = EditorGUI.Popup(buttonRect, (usePlain.boolValue) ? 0 : (useConstant.boolValue) ? 1 : 2, popupOptions, popupStyle);
            usePlain.boolValue = _index == 0;
            useConstant.boolValue = _index == 1;
            
            EditorGUI.PropertyField(position, (usePlain.boolValue) ? plainValue : (useConstant.boolValue) ? constantValue : variableValue, GUIContent.none);
          
            if (EditorGUI.EndChangeCheck())
            {
                if (property.serializedObject.hasModifiedProperties)
                {
                    property.serializedObject.ApplyModifiedProperties();
                }
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}
