using System;
using HarmonyLib;
namespace AutoPauseOnLoad
{
	public class Plugin : Mod
	{
		internal static ModLogger ModLogger = null!;
		public void Awake()
		{
			ModLogger = Logger;
			Harmony.PatchAll();
		}

	}
}
