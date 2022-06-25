using MelonLoader;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("CustomLoadAudio")]
[assembly: AssemblyDescription("A melonloader mod that changes the load audio in vrchat")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Mezque")]
[assembly: AssemblyProduct("CustomLoadAudio")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("Mezque")]
[assembly: AssemblyCulture("")]
[assembly: MelonInfo(typeof(CustomLoadingAudio.Main), "CustomLoadAudio", $"{AssemblyInfo.Version}", "Mezque + Dotlezz")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(System.ConsoleColor.DarkMagenta)]
[assembly: MelonAuthorColor(System.ConsoleColor.Magenta)]
[assembly: ComVisible(false)]
[assembly: Guid("3adc9acc-d839-403b-bae0-c114293d7dda")]
[assembly: AssemblyVersion($"{AssemblyInfo.Version}")]
[assembly: AssemblyFileVersion($"{AssemblyInfo.Version}")]

internal struct AssemblyInfo
{
    internal const string Version = "3.0.0.0";
}