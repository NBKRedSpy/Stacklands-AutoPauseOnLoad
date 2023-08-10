using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace AutoPauseOnLoad
{

	[HarmonyPatch(typeof(MainMenu), "Awake")]
	public static class MainMenu_Patch
	{
		public static void Postfix(MainMenu __instance)
		{
			__instance.ContinueButton.Clicked += () =>
			{
				Plugin.PauseGame();
			};
		}
	}
}

