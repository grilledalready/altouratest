using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class AddressableLoaderBase : MonoBehaviour
{
    private Dictionary<string, (Vector3 position, Vector3 scale)> loadParameters = new Dictionary<string, (Vector3, Vector3)>();

    protected void LoadAsset(string address, Vector3 position = default, Vector3 scale = default)
    {
        position = position == default ? Vector3.zero : position;
        scale = scale == default ? Vector3.one : scale;
        loadParameters[address] = (position, scale);
        var handle = Addressables.LoadAssetAsync<GameObject>(address);
        var wrappedHandle = new WrappedHandle<GameObject>(handle, address);
        handle.Completed += (op) => OnAssetLoaded(wrappedHandle);
    }

    private void OnAssetLoaded(WrappedHandle<GameObject> wrappedHandle)
    {
        if (wrappedHandle.Handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject loadedAsset = Instantiate(wrappedHandle.Handle.Result);
            if (loadParameters.TryGetValue(wrappedHandle.Address, out var parameters))
            {
                PositionAsset(loadedAsset, parameters.position, parameters.scale);
                loadParameters.Remove(wrappedHandle.Address);
            }
            HandleLoadedAsset(loadedAsset);
        }
        else
        {
            Debug.LogError("Failed to load asset.");
        }
    }

    private void PositionAsset(GameObject asset, Vector3 position, Vector3 scale)
    {
        asset.transform.position = position;
        asset.transform.localScale = scale;
    }

    protected abstract void HandleLoadedAsset(GameObject asset);

    protected class WrappedHandle<T>
    {
        public AsyncOperationHandle<T> Handle { get; private set; }
        public string Address { get; private set; }

        public WrappedHandle(AsyncOperationHandle<T> handle, string address)
        {
            Handle = handle;
            Address = address;
        }
    }
}
