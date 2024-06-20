using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomepageManager : MonoBehaviour
{
    public static HomepageManager instance;

    public delegate void GLBModeSetEvent();
    public static event GLBModeSetEvent OnGLBModeSetEvent;

    public SpawnPositions spawnPositions;

    private void Awake()
    {
        instance = this;
    }


    public void LoadVideoStreaming()
    {
        LoadAddressableGLB.instance.LoadGLB(ApplicationManager.instance.assetReferences.arenaPath, Vector3.zero, Vector3.one * 0.1F);
        AddressablePrefabLoader.Instance.LoadPrefab(ApplicationManager.instance.assetReferences.videoPrefabPath, spawnPositions.panelStartPosition, Vector3.one * 0.005F);
        Camera.main.transform.position = spawnPositions.playerStartPosition;
        Camera.main.transform.eulerAngles = new Vector3(0, 90, 0);
        UIManager.Instance.HandleMainScreen(false);
    }
    public void LoadGLB()
    {
        LoadAddressableGLB.instance.LoadGLB(ApplicationManager.instance.assetReferences.arenaPath, Vector3.zero, Vector3.one * 0.1F);
        Camera.main.transform.position = spawnPositions.playerStartPosition;
        Camera.main.transform.eulerAngles = new Vector3(0, 90, 0);
        LoadAddressableGLB.instance.LoadGLB(ApplicationManager.instance.assetReferences.glbPath, spawnPositions.sampleGLBSpawnPosition, spawnPositions.sampleGLBSpawnScale);
        UIManager.Instance.HandleMainScreen(false);
        OnGLBModeSetEvent?.Invoke();
    }
}
