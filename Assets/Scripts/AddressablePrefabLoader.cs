using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablePrefabLoader : MonoBehaviour
{
    public static AddressablePrefabLoader Instance;

    private void Awake()
    {
        Instance = this;
    }


    private GameObject loadedPrefabInstance;

    // Method to load the prefab
    public void LoadPrefab(string prefabAddress)
    {
        Addressables.LoadAssetAsync<GameObject>(prefabAddress).Completed += OnPrefabLoaded;
    }

    // Callback when the prefab is loaded
    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            loadedPrefabInstance = Instantiate(handle.Result);
            Debug.Log("Prefab loaded and instantiated successfully.");
        }
        else
        {
            Debug.LogError("Failed to load prefab.");
        }
    }

    // Method to unload the prefab
    public void UnloadPrefab()
    {
        if (loadedPrefabInstance != null)
        {
            Destroy(loadedPrefabInstance);
            Addressables.ReleaseInstance(loadedPrefabInstance);
            loadedPrefabInstance = null;
            Debug.Log("Prefab unloaded successfully.");
        }
    }
}
