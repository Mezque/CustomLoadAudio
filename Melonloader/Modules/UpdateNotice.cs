using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace CustomLoadAudio.Modules
{
    internal class UpdateNotice
    {
        internal static void UpdateCheck()
        {
            using var sha = SHA256.Create();
            var gitURL = "https://github.com/Mezque/CustomLoadAudio/releases/latest/download/MLCustomLoadAudio.dll";
            byte[] DllCur = null;
            byte[] DLLupdate = null;
            var ModDLL = "Mods//MLCustomLoadAudio.dll";
            using var wc = new WebClient();

            if (File.Exists(ModDLL))
            {
                DllCur = File.ReadAllBytes(ModDLL);
            }
            try
            {
                DLLupdate = wc.DownloadData($"{gitURL}");
            }
            catch (WebException ex)
            {
                CustomLoadAudio.Modules.ModLog.MogLog.Warn($"Unable to check for mod update \n{ex}");
            }
            try
            {
                string CurModHash = ComputeHash(sha, DllCur);
                string UpdateModHash = ComputeHash(sha, DLLupdate);

                if (CurModHash != UpdateModHash)
                {
                    CustomLoadAudio.Modules.ModLog.MogLog.Warn($"There Is A Mod Update Available At:\n {gitURL}\n Certan Features May NOT Work Until You Update!");
                }
                else
                {
                    CustomLoadAudio.Modules.ModLog.MogLog.Msg(ConsoleColor.White, "[INFO] No Updates Available :)");
                }
            }
            catch(Exception ex)
            {
                CustomLoadAudio.Modules.ModLog.MogLog.Warn($"{ex}");
            }
        }

        private static string ComputeHash(HashAlgorithm sha256, byte[] data)
        {
            byte[] array = sha256.ComputeHash(data);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in array)
            { stringBuilder.Append(b.ToString("x2")); }
            return stringBuilder.ToString();
        }
    }
}
