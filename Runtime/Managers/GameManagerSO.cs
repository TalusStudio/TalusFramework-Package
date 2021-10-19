using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu]
    public class GameManagerSO : BaseSO
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Application.targetFrameRate = 60;
        }

        [Required]
        [SerializeField]
        [AssetSelector(DropdownTitle = "GameData Scriptables")]
        [LabelWidth(70)]
        private GameDataSO _GameData;

        [TitleGroup("Time Settings", "Sets time scale", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
        [Button(ButtonSizes.Large), GUIColor(1, 0, 0)]
        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        [TitleGroup("Time Settings")]
        [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
        public void UnpauseGame()
        {
            Time.timeScale = 1f;
        }

        [TitleGroup("Scene Management", "Activates on Play Mode!", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
        [DisableInEditorMode]
        [Button(ButtonSizes.Large)]
        public void RestartLevel()
        {
            SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        [TitleGroup("Scene Management")]
        [DisableInEditorMode]
        [Button(ButtonSizes.Large)]
        public void LoadNextLevel()
        {
            SceneLoader.Instance.LoadScene(_GameData.GetNextLevelIndex());
        }
    }
}
