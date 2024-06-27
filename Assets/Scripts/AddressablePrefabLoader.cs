using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressablePrefabLoader : AddressableLoaderBase
{
    public static AddressablePrefabLoader Instance;

    private GameObject loadedPrefabInstance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadPrefab(string prefabAddress, Vector3 position = default, Vector3 scale = default)
    {
        LoadAsset(prefabAddress, position, scale);
    }

    protected override void HandleLoadedAsset(GameObject asset)
    {
        loadedPrefabInstance = asset;
    }

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
