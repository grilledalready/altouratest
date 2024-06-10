using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAddressableGLB : MonoBehaviour
{
    public static LoadAddressableGLB instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadGLB(string glbAddress)
    {
        // Start loading the GLB file
        Addressables.LoadAssetAsync<GameObject>(glbAddress).Completed += OnGLBLoaded;
    }

    void OnGLBLoaded(AsyncOperationHandle<GameObject> obj)
    {
        print("Loaded");
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject glbTextAsset = obj.Result;

            Instantiate(glbTextAsset);
        }
        else
        {
            Debug.LogError("Failed to load GLB file.");
        }
    }
}
