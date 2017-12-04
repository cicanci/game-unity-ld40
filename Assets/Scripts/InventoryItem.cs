using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour 
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

    public float CurrentProduction { private set; get; }

    private float _productionPerSecond;
    private int _maxProduction;
    private float _timer;
    private int _lastSecond;
    private bool _initialized;

    public void Initialize()
    {
        switch(_resourceType)
        {
            case ResourceType.Water:
                CurrentProduction = RemoteSettingsCache.InitialWater;
                _productionPerSecond = RemoteSettingsCache.WaterPerSecond;
                _maxProduction = RemoteSettingsCache.MaxWater;
                break;
            case ResourceType.Food:
                CurrentProduction = RemoteSettingsCache.InitialFood;
                _productionPerSecond = RemoteSettingsCache.FoodPerSecond;
                _maxProduction = RemoteSettingsCache.MaxFood;
                break;
            case ResourceType.Gold:
                CurrentProduction = RemoteSettingsCache.InitialGold;
                _productionPerSecond = RemoteSettingsCache.GoldPerSecond;
                _maxProduction = RemoteSettingsCache.MaxGold;
                break;
        }

        _amountText.text = CurrentProduction + "";
        _initialized = true;
    }

    private void Update()
    {
        if(!_initialized)
        {
            return;
        }

        if(Mathf.RoundToInt(CurrentProduction) < _maxProduction)
        {
            _timer += Time.deltaTime;
            int seconds = Mathf.RoundToInt(_timer);

            if(Mathf.RoundToInt(_timer) > _lastSecond)
            {
                _lastSecond = seconds;
                CurrentProduction += _productionPerSecond;
                
                if(Mathf.RoundToInt(CurrentProduction) < _maxProduction)
                {
                    _amountText.color = Color.white;
                }
                else
                {
                    CurrentProduction = _maxProduction;
                    _amountText.color = Color.green;
                }

                _amountText.text = Mathf.RoundToInt(CurrentProduction).ToString();
            }
        }
    }
}
