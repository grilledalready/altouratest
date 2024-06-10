using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomepageManager : MonoBehaviour
{
    public static HomepageManager instance;

    public delegate void GLBModeSetEvent();
    public static event GLBModeSetEvent OnGLBModeSetEvent;

    private void Awake()
    {
        instance = this;
    }


    public void LoadVideoStreaming()
    {
        AddressablePrefabLoader.Instance.LoadPrefab(ApplicationManager.instance.assetReferences.videoPrefabPath);
        UIManager.Instance.HandleMainScreen(false);
    }
    public void LoadGLB()
    {
        LoadAddressableGLB.instance.LoadGLB(ApplicationManager.instance.assetReferences.glbPath);
        UIManager.Instance.HandleMainScreen(false);
        OnGLBModeSetEvent?.Invoke();
    }
}
