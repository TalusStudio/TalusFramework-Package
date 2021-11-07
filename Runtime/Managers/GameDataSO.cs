using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using QFSW.QC;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.Managers
{
	[CreateAssetMenu]
	[HideMonoScript]
	[CommandPrefix("talus.")]
	public class GameDataSO : BaseSO
	{
		private void OnEnable() => QuantumRegistry.RegisterObject(this);
		private void OnDisable() => QuantumRegistry.DeregisterObject(this);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			Application.targetFrameRate = 60;
		}

		[TitleGroup("Variables - Scene Management")]
		[Required]
		[AssetSelector(DropdownTitle = "Int Variables")]
		[LabelWidth(100)]
		public IntVariableSO NextLevelIndex;

		[TitleGroup("Variables - In Game")]
		[Required]
		[AssetSelector(DropdownTitle = "String Variables")]
		[LabelWidth(100)]
		public StringVariableSO LevelText;

		[TitleGroup("Variables - Scene Management")]
		[Required]
		[AssetSelector(DropdownTitle = "String Variables")]
		[LabelWidth(100)]
		public StringConstantSO LevelCyclePref;

		[Command("update-success-state-data", MonoTargetType.Registry)]
		public void SetSuccessData()
		{
			PlayerPrefs.SetInt(LevelCyclePref.Value, GetCompletedLevel() + 1);
			PlayerPrefs.Save();

			UpdateNextLevelVariable();
			UpdateLevelTextVariable();
		}

		public void UpdateNextLevelVariable() => NextLevelIndex.SetValue(Levels[GetCompletedLevel() % Levels.Count]);
		public void UpdateLevelTextVariable() => LevelText.SetValue("LEVEL " + (GetCompletedLevel() + 1));

		private static List<int> Levels
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

		[Command("get-level-pref", MonoTargetType.Registry)]
		private int GetCompletedLevel()
		{
			if (PlayerPrefs.HasKey(LevelCyclePref.Value))
			{
				return PlayerPrefs.GetInt(LevelCyclePref.Value);
			}

			PlayerPrefs.SetInt(LevelCyclePref.Value, 0);
			PlayerPrefs.Save();

			return PlayerPrefs.GetInt(LevelCyclePref.Value);
		}
	}
}
