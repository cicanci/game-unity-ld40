using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour 
{
    public enum ResourceType
    {
        Water,
        Food,
        Gold
    }

    [SerializeField]
    private ResourceType _resourceType;
    
    [SerializeField]
    private Text _amountText;

    private float _currentProduction;
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
                _currentProduction = RemoteSettingsCache.InitialWater;
                _productionPerSecond = RemoteSettingsCache.WaterPerSecond;
                _maxProduction = RemoteSettingsCache.MaxWater;
                break;
            case ResourceType.Food:
                _currentProduction = RemoteSettingsCache.InitialFood;
                _productionPerSecond = RemoteSettingsCache.FoodPerSecond;
                _maxProduction = RemoteSettingsCache.MaxFood;
                break;
            case ResourceType.Gold:
                _currentProduction = RemoteSettingsCache.InitialGold;
                _productionPerSecond = RemoteSettingsCache.GoldPerSecond;
                _maxProduction = RemoteSettingsCache.MaxGold;
                break;
        }

        _amountText.text = _currentProduction + "";
        _initialized = true;
    }

    private void Update()
    {
        if(!_initialized)
        {
            return;
        }

        if(Mathf.RoundToInt(_currentProduction) < _maxProduction)
        {
            _timer += Time.deltaTime;
            int seconds = Mathf.RoundToInt(_timer);

            if(Mathf.RoundToInt(_timer) > _lastSecond)
            {
                _lastSecond = seconds;
                _currentProduction += _productionPerSecond;
                
                if(Mathf.RoundToInt(_currentProduction) < _maxProduction)
                {
                    _amountText.color = Color.white;
                }
                else
                {
                    _currentProduction = _maxProduction;
                    _amountText.color = Color.green;
                }

                _amountText.text = Mathf.RoundToInt(_currentProduction).ToString();
            }
        }
    }
}
