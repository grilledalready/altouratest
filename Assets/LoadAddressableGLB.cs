using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static LoadAddressableGLB;

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
        print(glbAddress);
        var handle = Addressables.LoadAssetAsync<GameObject>(glbAddress);
        var wrappedHandle = new WrappedHandle<GameObject>(handle, glbAddress);
        handle.Completed += (op) => OnGLBLoaded(wrappedHandle);
    }

    void OnGLBLoaded(WrappedHandle<GameObject> wrappedHandle)
    {
        print("Loaded");
        var obj = wrappedHandle.Handle;
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject glbTextAsset = obj.Result;
            GameObject newAsset = Instantiate(glbTextAsset);

            string address = wrappedHandle.Address;
            if (loadParameters.TryGetValue(address, out var parameters))
            {
                PositionNewAsset(newAsset, parameters.position, parameters.scale);
                loadParameters.Remove(address);
                print(address);
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

    public class WrappedHandle<T>
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


