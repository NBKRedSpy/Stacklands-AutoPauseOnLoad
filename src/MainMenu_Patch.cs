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
				//Just in case there are other mods that also set the auto pause
				//For example, my Auto Continue mod does this as well.

				// This is awaiting the ModManifest supporting an Incompatible entry.
				if (WorldManager.instance.SpeedUp != 0)
				{
					GameScreen.instance?.TimePause();
				}
			};
		}
	}
}

