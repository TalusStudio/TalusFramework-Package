using System.Collections.Generic;
using System.Linq;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Utility;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Scene Collection", menuName = "Collections/Scene", order = 6)]
    public class SceneCollection : BaseCollection<SceneReference>
    {
        #if UNITY_EDITOR
            [Button(ButtonSizes.Large), GUIColor(0f, 1f, 0f)]
            public void SyncBuildSettings()
            {
                var scenes = new List<EditorBuildSettingsScene>();
                scenes.AddRange(Items.Select(t => new EditorBuildSettingsScene(t.ScenePath, true)));
                EditorBuildSettings.scenes = scenes.ToArray();
            }
        #endif
    }
}