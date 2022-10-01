using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(ConfigHack.BuildInfo.Description)]
[assembly: AssemblyDescription(ConfigHack.BuildInfo.Description)]
[assembly: AssemblyProduct(ConfigHack.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + ConfigHack.BuildInfo.Author)]
[assembly: AssemblyVersion(ConfigHack.BuildInfo.Version)]
[assembly: AssemblyFileVersion(ConfigHack.BuildInfo.Version)]
[assembly: MelonInfo(typeof(ConfigHack.ConfigHackMod), ConfigHack.BuildInfo.Name, ConfigHack.BuildInfo.Version, ConfigHack.BuildInfo.Author, ConfigHack.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Alpha Blend Interactive", "ChilloutVR")]
