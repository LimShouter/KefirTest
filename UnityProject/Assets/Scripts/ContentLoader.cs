using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.XR;

public class ContentLoader<T> : IContentLoader 
{
    public event Action Loaded; 
        
    public AsyncOperationHandle<T> Handler;
    private string _key;
    private bool isLoaded;

    public ContentLoader(string key)
    {
        _key = key;
    }

    public void Load()
    {
        Handler = Addressables.LoadAssetAsync<T>(_key);
        Handler.Completed += OnCompleteLoad;
    }

    private void OnCompleteLoad(AsyncOperationHandle<T> obj)
    {
        Handler.Completed -= OnCompleteLoad;
        isLoaded = true;
        Loaded?.Invoke();
    }

    public void Unload()
    {
        if (isLoaded)
        {
            Addressables.Release(Handler);
        }
    }
        
}