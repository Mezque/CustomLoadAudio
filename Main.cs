using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CustomLoadingAudio;

public class Main : MelonMod
{
    private static readonly MelonPreferences_Category CLA = MelonPreferences.CreateCategory("CLA", "Custom Load Audio");

    private static MelonPreferences_Entry<string> _path = CLA.CreateEntry("path", $"{MelonUtils.GameDirectory}\\UserData\\CustomLoadAudio\\music.wav", "Audio File Path", "The file path the audio will be loaded from.");

    public override void OnApplicationStart()
    {
        if (!System.IO.Directory.Exists($"{MelonUtils.GameDirectory}\\UserData\\CustomLoadAudio"))
        {
            System.IO.Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\UserData\\CustomLoadAudio");
        }
        LoggerInstance.Msg(ConsoleColor.Yellow, $"\n" +
            $"[INFO] Custom Load Audio V{AssemblyInfo.Version} Has Loaded!\n" +
            $"[INFO] Your File Path To Load Audio From Is {_path.Value}\n" +
            $"[INFO] You Can Configure This In The MelonPrefreneces Or With UIX!");
        MelonCoroutines.Start(SetAudio());
    }

    private static IEnumerator SetAudio()
    {
        if (_path.Value == "") yield break;

        var clip = UnityWebRequest.Get(_path.Value);
        clip.SendWebRequest();
        while (!clip.isDone) yield return null;
        if (clip.isHttpError) yield break;

        var audioclip = WebRequestWWW.InternalCreateAudioClipUsingDH(clip.downloadHandler, clip.url, false, false, AudioType.UNKNOWN);

        audioclip.hideFlags = HideFlags.DontUnloadUnusedAsset;

        while (VRCUiPageLoading.field_Internal_Static_VRCUiPageLoading_0 == null) yield return null;

        var source = VRCUiPageLoading.field_Internal_Static_VRCUiPageLoading_0.transform.Find("LoadingSound").GetComponent<AudioSource>();
        source.clip = audioclip;
        source.Play();
    }
}