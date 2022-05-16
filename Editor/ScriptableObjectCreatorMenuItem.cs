using System;
using System.Linq;
using System.Text.RegularExpressions;

using UnityEngine;

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;

namespace TalusFramework.Editor
{
    internal class ScriptableObjectCreatorMenuItem : OdinMenuItem
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
                _Creator.PopulatePreviewObject(_Type);
                _Creator.CreateAsset(_Type);
            }
        }
    }
}