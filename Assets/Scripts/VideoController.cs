using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer player;
    void Start()
    {
        LoadAndPlayVideo();
    }

    public void LoadAndPlayVideo()
    {
        Addressables.LoadAssetAsync<VideoClip>(ApplicationManager.instance.assetReferences.videoPath).Completed += OnVideoLoaded;
    }

    private void OnVideoLoaded(AsyncOperationHandle<VideoClip> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            VideoClip videoClip = handle.Result;
            player.clip = videoClip;
            player.Play();
            Debug.Log("Video loaded and playing.");
        }
        else
        {
            Debug.LogError("Failed to load video.");
        }
    }
}
