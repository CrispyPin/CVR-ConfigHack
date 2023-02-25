// using System;
using System.IO;
using System.Collections.Generic;

using UnityEngine;
using MelonLoader;
using HarmonyLib;

using ABI_RC.Core.Savior;
using ABI_RC.Systems.IK.SubSystems;
using Valve.Newtonsoft.Json;

namespace ConfigHack
{
	public static class BuildInfo
	{
		public const string Name = "ConfigHack";
		public const string Description = "Loads configs from a different file because Proton :)";
		public const string Author = "CrispyPin";
		public const string Version = "0.2.0";
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

	[HarmonyPatch(typeof(BodySystem), "SaveSavedCalibrations")]
	static class CalibrationSavingPatch
	{
		static void Postfix(Dictionary<string, BodySystem.CalibrationData> ___SavedAvatars)
		{
			File.WriteAllText(Application.persistentDataPath + "/saved_calibrations2.json", JsonConvert.SerializeObject(___SavedAvatars, Formatting.None, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			}));
		}
	}

	[HarmonyPatch(typeof(BodySystem), "TryLoadSavedCalibrations")]
	static class CalibrationLoadingPatch
	{
		static void Postfix(ref Dictionary<string, BodySystem.CalibrationData> ___SavedAvatars)
		{
			if (File.Exists(Application.persistentDataPath + "/saved_calibrations2.json"))
			{
				Dictionary<string, BodySystem.CalibrationData> dictionary = JsonConvert.DeserializeObject<Dictionary<string, BodySystem.CalibrationData>>(File.ReadAllText(Application.persistentDataPath + "/saved_calibrations2.json"));
				if (dictionary != null)
				{
					___SavedAvatars = dictionary;
				}
			}
		}
	}
}