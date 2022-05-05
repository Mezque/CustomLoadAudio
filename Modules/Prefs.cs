using MelonLoader;
using UnityEngine;

namespace CustomLoadAudio.Modules
{
    internal class Prefs
    {
        internal static void InitPrefs()
        {
            CLA = MelonPreferences.CreateCategory("Custom Load Audio");
            FileName = CLA.CreateEntry("Audio File Name", "music.wav", "Audio File Name", "The name of the audio file you wish to load, default 'music.wav'");
            MelonLoader.MelonPreferences.Save();
        }
        internal static MelonPreferences_Category CLA;
        internal static MelonPreferences_Entry<string> FileName;
    }
}
