using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UIElements;

public class LoadAddressableGLB : MonoBehaviour
{
    public static LoadAddressableGLB instance;

    private void Awake()
    {
        instance = this;
    }

    private Dictionary<string, (Vector3 position, Vector3 scale)> loadParameters = new Dictionary<string, (Vector3, Vector3)>();


    public void LoadGLB(string glbAddress, Vector3 position = default, Vector3 scale = default)
    {
        position = position == default ? Vector3.zero : position;
        scale = scale == default ? Vector3.one : scale;
        loadParameters[glbAddress] = (position, scale);

        Addressables.LoadAssetAsync<GameObject>(glbAddress).Completed += OnGLBLoaded;
    }

    void OnGLBLoaded(AsyncOperationHandle<GameObject> obj)
    {
        print("Loaded");
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject glbTextAsset = obj.Result;
            GameObject newAsset = Instantiate(glbTextAsset);
           
            if (loadParameters.TryGetValue(obj.DebugName, out var parameters))
            {
                PositionNewAsset(newAsset, parameters.position, parameters.scale);
                loadParameters.Remove(obj.DebugName);
            }

            SpawnedObjectsManager.Instance.AddObject(newAsset);
        }
        else
        {
            Debug.LogError("Failed to load GLB file.");
        }
    }

    private void PositionNewAsset(GameObject asset, Vector3 position, Vector3 scale)
    {
        asset.transform.position = position;
        asset.transform.localScale = scale;
    }
}
