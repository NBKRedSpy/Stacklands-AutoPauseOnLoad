using System;
using HarmonyLib;

namespace AutoPauseOnLoad
{

	[HarmonyPatch(typeof(TransitionScreen), "StartTransition", new Type[] { typeof(Action), typeof(TransitionType), typeof(float)})]
	public static class TransitionScreen_Patch
	{
		public static void Postfix(TransitionScreen __instance, Action onTransition, ref Action ___onTransition)
		{

			if (onTransition != null && Plugin.PauseOnBoardChange.Value)
			{
				___onTransition = () => { 
					onTransition();
					Plugin.PauseGame();
				};
			}
		}

	}
}
