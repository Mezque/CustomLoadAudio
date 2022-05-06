using System;
using System.Collections;
using MelonLoader;
using UnityEngine;
using UnityEngine.Networking;

[assembly:
    MelonInfo(typeof(CustomLoadingAudio.MelonEntry), "CustomLoadingAudio", "1.1.1.0", "Dotlezz",
        "https://github.com/Dotlezz/CustomLoadingAudio")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]

namespace CustomLoadingAudio;

public class MelonEntry : MelonMod
{
    private static readonly MelonPreferences_Category Cla =
        MelonPreferences.CreateCategory("CLA", "Custom Loading Audio");

    private static MelonPreferences_Entry<string> _path =
        Cla.CreateEntry("path", "", "Audio File Path", "The file path the audio will be loaded from.");

    public override void OnApplicationStart() => MelonCoroutines.Start(SetAudio());

    private static IEnumerator SetAudio()
    {
        if (_path.Value == "") yield break;

        var clip = UnityWebRequest.Get(_path.Value);
        clip.SendWebRequest();
        while (!clip.isDone) yield return null;
        if (clip.isHttpError) yield break;

        var audioclip =
            WebRequestWWW.InternalCreateAudioClipUsingDH(clip.downloadHandler, clip.url, false, false,
                AudioType.UNKNOWN);

        audioclip.hideFlags = HideFlags.DontUnloadUnusedAsset;

        while (MonoBehaviourPublicObVoBoAwVoBoVoBoVoBoUnique
                   .field_Private_Static_MonoBehaviourPublicObVoBoAwVoBoVoBoVoBoUnique_0 == null)
            yield return null;

        var source1 = MonoBehaviourPublicObVoBoAwVoBoVoBoVoBoUnique
            .field_Private_Static_MonoBehaviourPublicObVoBoAwVoBoVoBoVoBoUnique_0.transform.Find("LoadingSound")
            .GetComponent<AudioSource>();
        source1.clip = audioclip;
        source1.Play();

        while (VRCUiPageLoading.field_Internal_Static_VRCUiPageLoading_0 == null) yield return null;

        var source2 = VRCUiPageLoading.field_Internal_Static_VRCUiPageLoading_0.transform.Find("LoadingSound")
            .GetComponent<AudioSource>();
        source2.clip = audioclip;
        source2.Play();
    }
}