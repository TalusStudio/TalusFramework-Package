using System;
using System.Threading.Tasks;

namespace TalusFramework.Runtime.Utility
{
	public static class AsyncUtility
	{
		public static async Task PollUntilAsync(int pollInterval, Func<bool> predicate)
		{
			while (!predicate())
			{
				await Task.Delay(pollInterval);
			}
		}
	}
}
