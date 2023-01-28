using MelonLoader;
// using HarmonyLib;
// using System;
using System.IO;
// using System.Reflection;
using UnityEngine;


// using ABI_RC.Core;
// using ABI_RC.Core.IO;
// using ABI_RC.Core.Player;
using ABI_RC.Core.Savior;

namespace ConfigHack
{
	public static class BuildInfo
	{
		public const string Name = "ConfigHack";
		public const string Description = "Loads configs from a different file because Proton :)";
		public const string Author = "CrispyPin";
		public const string Version = "0.1.0";
		public const string DownloadLink = "https://github.com/CrispyPin/CVR-ConfigHack/releases";
	}

	public class ConfigHackMod : MelonMod
	{
		public override void OnLateInitializeMelon()
		{
			MelonLogger.Msg("Started ConfigHack");
			LoadAlternateConfig();
		}

		public override void OnApplicationQuit()
		{
			SaveAlternateConfig();
		}

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			if (buildIndex == -1) // loaded world scene
			{
				SaveAlternateConfig();
			}
		}

		void LoadAlternateConfig()
		{
			MelonLogger.Msg("Loading from game2.config");
			CVRFileSettings cVRFileSettings = (CVRFileSettings)JsonUtility.FromJson(File.ReadAllText(ConfigPath()), typeof(CVRFileSettings));
			if (cVRFileSettings != null)
			{
				MetaPort.Instance.settings.LoadSerializedSettings(cVRFileSettings);
			}
		}

		void SaveAlternateConfig()
		{
			MelonLogger.Msg("Saving to game2.config");
			CVRFileSettings settings = MetaPort.Instance.settings.GetSerializedSettings();
			File.WriteAllText(ConfigPath(), JsonUtility.ToJson(settings, true));
		}

		string ConfigPath()
		{
			return Application.persistentDataPath + "/game2.config";
		}
	}
}