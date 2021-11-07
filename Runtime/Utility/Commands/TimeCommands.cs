#if ENABLE_COMMANDS
using QFSW.QC;

using UnityEngine;

namespace TalusFramework.Runtime.Utility.Commands
{
	[CommandPrefix("talus.")]
	public static class TimeCommands
	{
		[Command("time-scale", "the scale at which time is passing by.")]
		private static float TimeScale
		{
			get => Time.timeScale;
			set => Time.timeScale = value;
		}
	}
}
#endif
