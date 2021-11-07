#if ENABLE_COMMANDS
using System;
using System.Collections;

using QFSW.QC;

using UnityEngine;

namespace TalusFramework.Runtime.Utility.Commands
{
	[AddComponentMenu("")]
	[CommandPrefix("talus.")]
	public class CoroutineCommands : MonoBehaviour
	{
		[Command("start-coroutine", "starts the supplied command as a coroutine", MonoTargetType.Singleton)]
		private void StartCoroutineCommand(string coroutineCommand)
		{
			object coroutineReturn = QuantumConsoleProcessor.InvokeCommand(coroutineCommand);

			if (coroutineReturn is IEnumerator)
			{
				StartCoroutine(coroutineReturn as IEnumerator);
			}
			else
			{
				throw new ArgumentException($"{coroutineCommand} is not a coroutine");
			}
		}
	}
}
#endif
