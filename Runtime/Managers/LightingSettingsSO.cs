using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility.Logging;
using UnityEngine;
using UnityEngine.Rendering;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu]
    [HideMonoScript]
    public class LightingSettingsSO : BaseSO
    {
#region POST PROCESS
        [FoldoutGroup("1 - Post Process Settings")]
        [Required]
        [SerializeField]
        private VolumeProfile PostProcessVolume;
#endregion

#region SKYBOX
        [FoldoutGroup("2 - Skybox Settings")]
        [Required]
        [SerializeField]
        private Material SkyboxMaterial;
#endregion
        
#region AMBIENT
        [FoldoutGroup("3 - Ambient Settings")]
        [EnumPaging]
        [SerializeField]
        private AmbientMode AmbientType = AmbientMode.Flat;

        [FoldoutGroup("3 - Ambient Settings")]
        [ShowIf("@AmbientType == AmbientMode.Flat")]
        [ColorPalette("Lightnings")]
        [SerializeField]
        private Color AmbientColor;

        [FoldoutGroup("3 - Ambient Settings")]
        [ShowIf("@AmbientType == AmbientMode.Skybox")]
        [SerializeField]
        private float AmbientIntensity;
        
        [FoldoutGroup("3 - Ambient Settings")]
        [ShowIf("@AmbientType == AmbientMode.Trilight")]
        [ColorPalette("Lightnings")]
        [SerializeField]
        private Color TopColor;
        
        [FoldoutGroup("3 - Ambient Settings")]
        [ShowIf("@AmbientType == AmbientMode.Trilight")]
        [ColorPalette("Lightnings")]
        [SerializeField]
        private Color MiddleColor;
        
        [FoldoutGroup("3 - Ambient Settings")]
        [ShowIf("@AmbientType == AmbientMode.Trilight")]
        [ColorPalette("Lightnings")]
        [SerializeField]
        private Color GroundColor;
#endregion
        
#region FOG
        [FoldoutGroup("4 - Fog Settings")]
        [SerializeField]
        private bool UseFog;

        [FoldoutGroup("4 - Fog Settings")]
        [ShowIf("UseFog")]
        [SerializeField]
        private FogMode FogMode = FogMode.ExponentialSquared;

        [FoldoutGroup("4 - Fog Settings")]
        [ShowIf("UseFog")]
        [ColorPalette("Lightnings")]
        [SerializeField]
        private Color FogColor;

        [FoldoutGroup("4 - Fog Settings")]
        [ShowIf("@this.UseFog && (this.FogMode == UnityEngine.FogMode.ExponentialSquared || this.FogMode == UnityEngine.FogMode.Exponential)")]
        [SerializeField]
        private float FogIntensity = 0.01f;

        [FoldoutGroup("4 - Fog Settings")]
        [ShowIf("@this.FogMode == UnityEngine.FogMode.Linear")]
        [MinMaxSlider(0f, 1000f)]
        [SerializeField]
        private Vector2 FogStartEnd;
#endregion

        [Button(ButtonSizes.Large), GUIColor(0f, 1f, 0f)]
        public void ApplySettings()
        {
            RenderSettings.ambientMode = AmbientType;
            RenderSettings.skybox = SkyboxMaterial;
            
            switch (AmbientType)
            {
                case AmbientMode.Skybox:
                    RenderSettings.ambientIntensity = AmbientIntensity;
                    break;
                case AmbientMode.Flat:
                    RenderSettings.ambientLight = AmbientColor;
                    break;
                case AmbientMode.Trilight:
                    RenderSettings.ambientSkyColor = TopColor;
                    RenderSettings.ambientEquatorColor = MiddleColor;
                    RenderSettings.ambientGroundColor = GroundColor;
                    break;
                default:
                    RenderSettings.ambientMode = AmbientMode.Flat;
                    RenderSettings.ambientLight = AmbientColor;
                    break;
            }
            TLog.Log("Ambient settings initialized!");

            Volume postProcessVolume = FindObjectOfType<Volume>();
            if (postProcessVolume != null)
            {
                postProcessVolume.profile = PostProcessVolume;
                TLog.Log("Post process initialized!");
            }
            else
            {
                TLog.Log("Post process volume not found in active scene!", LogType.Error);
            }

            RenderSettings.fog = UseFog;
            
            if (UseFog)
            {
                RenderSettings.fogMode = FogMode;
                RenderSettings.fogColor = FogColor;
                RenderSettings.fogDensity = FogIntensity;

                if (FogMode == FogMode.Linear)
                {
                    RenderSettings.fogStartDistance = FogStartEnd.x;
                    RenderSettings.fogEndDistance = FogStartEnd.y;
                }
            }
            
            // If you change the skybox in playmode, you have to use the DynamicGI.UpdateEnvironment
            // function call to update the ambient probe.
            DynamicGI.UpdateEnvironment();
        }
    }
}
