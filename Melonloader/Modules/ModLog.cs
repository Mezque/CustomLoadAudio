using MelonLoader;
using System;

namespace CustomLoadAudio.Modules
{
    internal class ModLog
    {
        internal static class MogLog
        {
            internal static MelonLogger.Instance Conlog = new("CustomLoadAudio");
            internal static void Msg(ConsoleColor ConColour, string obj) => Conlog.Msg(ConColour, obj);
            internal static void Warn(string obj) => Conlog.Warning(obj);
        }
    }
}
