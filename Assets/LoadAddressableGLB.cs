using UnityEngine;

public class LoadAddressableGLB : AddressableLoaderBase
{
    public static LoadAddressableGLB instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadGLB(string glbAddress, Vector3 position = default, Vector3 scale = default)
    {
        LoadAsset(glbAddress, position, scale);
    }

    protected override void HandleLoadedAsset(GameObject asset)
    {
        SpawnedObjectsManager.Instance.AddObject(asset);
    }
}
