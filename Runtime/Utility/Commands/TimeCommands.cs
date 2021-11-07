#if ENABLE_COMMANDS
using UnityEngine;

using QFSW.QC;

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
