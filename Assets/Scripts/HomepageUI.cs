using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomepageUI : MonoBehaviour
{
    public Button videoStreamingModule;
    public Button glbLoadingModule;

    private void OnEnable()
    {
        videoStreamingModule.onClick.AddListener(() =>
        {
            HomepageManager.instance.LoadVideoStreaming();
        });

        glbLoadingModule.onClick.AddListener(() =>
        {
            HomepageManager.instance.LoadGLB();
        });
    }

    private void OnDisable()
    {
        videoStreamingModule.onClick?.RemoveAllListeners();
        glbLoadingModule.onClick?.RemoveAllListeners();
    }
}
