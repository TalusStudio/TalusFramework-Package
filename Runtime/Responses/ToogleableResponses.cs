using System;
using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{

	[Serializable]
	[Toggle("Enabled")]
	public class ToggleableResponses
	{
		public bool Enabled;

		[LabelWidth(75)]
		public List<BaseResponseSO> Responses;

		public void RaiseAll()
		{
			if (!Enabled)
			{
				TLog.Log("Trying to raise disabled responses!", LogType.Warning);
				return;
			}

			for (int i = 0; i < Responses.Count; ++i)
			{
				Responses[i].Invoke();
			}
		}
	}
}
