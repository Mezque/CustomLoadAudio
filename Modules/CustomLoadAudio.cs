using MelonLoader;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace CustomLoadAudio.Modules
{
    internal class CustomLoadAudio
    {
        internal static IEnumerator SetLoadAudio()
        {
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\UserData\\Mezque\\CustomLoadAudio"))
            {
                System.IO.Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\UserData\\Mezque\\CustomLoadAudio");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\UserData\\Mezque\\CustomLoadAudio\\{Prefs.FileName.Value}"))
            {
                ModLogger.Msg(ConsoleColor.White, $"No Custom Load Audio Found, To Use A Custom Audio Place A .wav File To Load From {MelonUtils.GameDirectory}\\UserData\\Mezque\\CustomLoadAudio\\{Prefs.FileName.Value} As Your Load Audio!");
            }
            if (File.Exists($"{MelonUtils.GameDirectory}\\UserData\\Mezque\\CustomLoadAudio\\{Prefs.FileName.Value}"))
            {
                ModLogger.Msg(ConsoleColor.White, $"Found Custom Load Audio, Using Audio From {MelonUtils.GameDirectory}\\UserData\\Mezque\\CustomLoadAudio\\{Prefs.FileName.Value} As Your Load Audio!");
                while (GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup") == null)
                    yield return null;
                var audioSource = GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup").GetComponentInChildren<AudioSource>(true);

                var unityWebRequest = UnityWebRequest.Get($"{MelonUtils.GameDirectory}\\UserData\\Mezque\\CustomLoadAudio\\{Prefs.FileName.Value}");
                unityWebRequest.SendWebRequest();
                while (!unityWebRequest.isDone)
                    yield return null;
                if (unityWebRequest.isHttpError)
                    yield break;
                var loadAudioSet = WebRequestWWW.InternalCreateAudioClipUsingDH(unityWebRequest.downloadHandler, unityWebRequest.url, false, false,
                    AudioType.UNKNOWN);

                loadAudioSet.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                audioSource.clip = loadAudioSet;
                yield break;
            }
        }
    }
}
