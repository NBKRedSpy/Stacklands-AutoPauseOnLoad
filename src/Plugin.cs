using System;
using HarmonyLib;
namespace AutoPauseOnLoad
{
	public class Plugin : Mod
	{

		public static ConfigEntry<bool> PauseOnBoardChange = null!;

		public static ModLogger ModLogger = null!;
		
		public void Awake()
		{
			PauseOnBoardChange = Config.GetEntry<bool>("Pause On Board Change", true, new ConfigUI()
			{
				Tooltip = "Pauses the game when the location is changed."
			});

			ModLogger = Logger;
			Harmony.PatchAll();
		}

		public static void PauseGame()
		{
			if (WorldManager.instance?.SpeedUp != 0)
			{
				GameScreen.instance?.TimePause();
			}
		}
	}
}
