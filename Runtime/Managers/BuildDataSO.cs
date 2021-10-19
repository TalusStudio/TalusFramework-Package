using System.Collections.Generic;
using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu]
    public class BuildDataSO : BaseSO
    {
        public static List<int> LevelIndexes
        {
            get
            {
                List<int> levelIndexes = new List<int>();

#if ENABLE_BACKEND
                // scene at buildIndex 0 -> elephant
                // scene at buildIndex 1 -> forwarder scene
                for (int i = 2; i < SceneManager.sceneCountInBuildSettings; ++i)
                {
                    levelIndexes.Add(i);
                }
#else
                // scene at buildIndex 0 -> forwarder scene
                for (int i = 1; i < SceneManager.sceneCountInBuildSettings; ++i)
                {
                    levelIndexes.Add(i);
                }
#endif
                return levelIndexes;
            }
        }

        public static int LevelCount => LevelIndexes.Count;

        [Required]
        [LabelWidth(100)]
        [AssetSelector(DropdownTitle = "String Constants")]
        public StringConstantSO LevelPlayerPref;

        public int GetLevelPlayerPrefValue()
        {
            if (PlayerPrefs.HasKey(LevelPlayerPref.Value))
            {
                return PlayerPrefs.GetInt(LevelPlayerPref.Value);
            }

            PlayerPrefs.SetInt(LevelPlayerPref.Value, 0);
            PlayerPrefs.Save();

            return PlayerPrefs.GetInt(LevelPlayerPref.Value);
        }

        public void IncrementPlayerPrefValue()
        {
            int completedLevel = GetLevelPlayerPrefValue();
            ++completedLevel;

            PlayerPrefs.SetInt(LevelPlayerPref.Value, completedLevel);
            PlayerPrefs.Save();
        }

    }
}
