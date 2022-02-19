#if ENABLE_COMMANDS
using QFSW.QC;

using UnityEngine;

namespace TalusFramework.Runtime.Utility.Commands
{
    [CommandPrefix("talus.")]
    public static class GraphicsCommands
    {
        [Command("max-fps", "the maximum FPS imposed on the application. Set to -1 for unlimited.")]
        private static int MaxFPS
        {
            get => Application.targetFrameRate;
            set => Application.targetFrameRate = value;
        }

        [Command("vsync", "enables or disables vsync for the application.")]
        private static bool VSync
        {
            get => QualitySettings.vSyncCount > 0;
            set => QualitySettings.vSyncCount = value ? 1 : 0;
        }
    }
}
#endif