using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace CustomLoadAudio.Modules
{
    internal class ModLogger
    {
        internal static MelonLogger.Instance Conlog = new("CustomLoadAudio", ConsoleColor.White);
        internal static void Msg(ConsoleColor ConColour, string obj) => Conlog.Msg(ConColour, obj);
        internal static void Error(string obj) => Conlog.Error(obj);
        internal static void Warning(string obj) => Conlog.Warning(obj);
    }
}
