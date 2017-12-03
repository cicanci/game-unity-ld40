using System.Collections;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private InventoryItem _water;
    [SerializeField]
    private InventoryItem _food;
    [SerializeField]
    private InventoryItem _gold;

    private void Start()
    {
        StartCoroutine(WaitForRemoteSettings());
    }

    private IEnumerator WaitForRemoteSettings()
    {
        while(!RemoteSettingsCache.Initialized)
        {
            yield return null;
        }

        _water.Initialize();
        _food.Initialize();
        _gold.Initialize();
    }
}
