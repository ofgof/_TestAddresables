using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Spawner : MonoBehaviour
{
    [SerializeField] private AssetReference reference;
    [SerializeField] private AssetReference reference2;
    // Start is called before the first frame update
    void Start()
    {
        reference.LoadAssetAsync<GameObject>().Completed += (asyncOperationHandle) =>
        {
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                reference.InstantiateAsync();
            }
        };
        reference2.LoadAssetAsync<GameObject>().Completed += (asyncOperationHandle) =>
        {
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                reference2.InstantiateAsync();
            }
        };
    }

}
