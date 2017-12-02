using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Default Values")]
    [SerializeField]
    private int _defaultWaterAmount;
    [SerializeField]
    private int _defaultFoodAmount;

    [Header("Text Fields")]
    [SerializeField]
    private Text _waterAmount;
    [SerializeField]
    private Text _foodAmount;

    private void Start()
    {
        RemoteSettings.Updated += HandleRemoteUpdate;
    }

    private void OnDestroy()
    {
        RemoteSettings.Updated -= HandleRemoteUpdate;
    }

    private void HandleRemoteUpdate()
    {
        _waterAmount.text = RemoteSettings.GetInt("initial_water", _defaultWaterAmount).ToString();
        _foodAmount.text = RemoteSettings.GetInt("initial_food", _defaultFoodAmount).ToString();
    }
}
