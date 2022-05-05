using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace CustomLoadAudio
{
    internal class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            Modules.Prefs.InitPrefs();
            Modules.ModLogger.Msg(ConsoleColor.Yellow, $"Custom Load Audio V{AssemblyInfo.Version} Has Loaded!");
            MelonCoroutines.Start(Modules.CustomLoadAudio.SetLoadAudio());
        }
    }
}
