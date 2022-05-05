using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle("CustomLoadAudio")]
[assembly: AssemblyDescription("A melonloader mod that changes the load audio in vrchat")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCompany("Mezque")]
[assembly: AssemblyProduct("CustomLoadAudio")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("Mezque")]
[assembly: AssemblyCulture("")]
[assembly: MelonInfo(typeof(CustomLoadAudio.Main), "CustomLoaderAudio", $"{AssemblyInfo.Version}", "Mezque")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(System.ConsoleColor.DarkMagenta)]
[assembly: MelonAuthorColor(System.ConsoleColor.Magenta)]
[assembly: ComVisible(false)]

[assembly: Guid("406b5b7b-9bb0-46e2-9eb1-723e33a88221")]

[assembly: AssemblyVersion($"{AssemblyInfo.Version}")]
[assembly: AssemblyFileVersion($"{AssemblyInfo.Version}")]

internal struct AssemblyInfo
{
    internal const string Version = "1.0.0.0";
}
