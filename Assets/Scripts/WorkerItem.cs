using UnityEngine;
using UnityEngine.UI;

public class WorkerItem : MonoBehaviour 
{
    private enum ResourceType
    {
        Water,
        Food,
        Gold
    }

    [SerializeField]
    private ResourceType _resourceType;

    [SerializeField]
    private Text _amountText;

    private int _currentAmount;

    private void Start()
    {
        _amountText.text = "0";
    }

    public void AddWorker()
    {
        if(_currentAmount < GetMaxAmount())
        {
            _currentAmount++;
            _amountText.text = _currentAmount + "";
        }
    }

    public void RemoveWorker()
    {
        if(_currentAmount > 0)
        {
            _currentAmount--;
            _amountText.text = _currentAmount + "";
        }
    }

    private int GetMaxAmount()
    {
        switch(_resourceType)
        {
            case ResourceType.Water:
                return RemoteSettingsCache.MaxWater;
            case ResourceType.Food:
                return RemoteSettingsCache.MaxFood;
            case ResourceType.Gold:
                return  RemoteSettingsCache.MaxGold;
        }
        return 0;
    }
}
