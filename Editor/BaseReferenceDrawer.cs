using TalusFramework.Runtime.References.Interfaces;

using UnityEditor;

using UnityEngine;

namespace TalusFramework.Editor
{
	[CustomPropertyDrawer(typeof(BaseReference))]
	public class BaseReferenceDrawer : PropertyDrawer
	{
		/// <summary>
		///     Options to display in the popup to select constant or variable.
		/// </summary>
		private readonly string[] popupOptions =
		{
			"Use Variable",
			"Use Constant"
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
			SerializedProperty useConstant = property.FindPropertyRelative("UseConstant");

			// Get values
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

			int index = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 1 : 0, popupOptions, popupStyle);
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
			EditorGUI.EndProperty();
		}
	}
}
