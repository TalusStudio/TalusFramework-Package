using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

using UnityEngine;

using TalusFramework.Runtime.Utility.Logging;

namespace TalusFramework.Editor.BuildUtility
{
	public class IncrementBuildNumber : IPreprocessBuildWithReport
	{
		public int callbackOrder => 0;

		public void OnPreprocessBuild(BuildReport report)
		{
			if (report.summary.platform != BuildTarget.iOS)
			{
				return;
			}

			if (int.TryParse(PlayerSettings.iOS.buildNumber, out int currentBuildNumber))
			{
				string nextBuildNumber = (currentBuildNumber + 1).ToString();
				PlayerSettings.iOS.buildNumber = nextBuildNumber;

				TLog.Log("Setting new iOS build number to " + nextBuildNumber);
			}
			else
			{
				TLog.Log("Failed to parse build number " + PlayerSettings.iOS.buildNumber + " as int.", LogType.Error);
			}
		}
	}
}
