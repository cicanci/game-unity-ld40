using UnityEngine;

public class RemoteSettingsCache : MonoBehaviour 
{
    [Header("Remote Settings - Local Values")]
    [SerializeField]
    private int _defaultInitialWater;
    [SerializeField]
    private int _defaultInitialFood;
    [SerializeField]
    private int _defaultInitialGold;
    [SerializeField]
    private float _defaultWaterPerSecond;
    [SerializeField]
    private float _defaultFoodPerSecond;
    [SerializeField]
    private float _defaultGoldPerSecond;
    [SerializeField]
    private int _defaultMaxWater;
    [SerializeField]
    private int _defaultMaxFood;
    [SerializeField]
    private int _defaultMaxGold;

    public static int InitialWater { private set; get; }
    public static int InitialFood { private set; get; }
    public static int InitialGold { private set; get; }
    public static float WaterPerSecond { private set; get; }
    public static float FoodPerSecond { private set; get; }
    public static float GoldPerSecond { private set; get; }
    public static int MaxWater { private set; get; }
    public static int MaxFood { private set; get; }
    public static int MaxGold { private set; get; }

    public static bool Initialized { private set; get; }

    private void Start()
    {
        if(Initialized)
        {
            return;
        }

#if ENABLE_REMOTE_SETTINGS
        RemoteSettings.Updated += HandleRemoteUpdate;
#else
        UseLocalSettings();
#endif
        DontDestroyOnLoad(gameObject);
    }

    private void HandleRemoteUpdate()
    {
        InitialWater = RemoteSettings.GetInt("initial_water", _defaultInitialWater);
        InitialFood = RemoteSettings.GetInt("initial_food", _defaultInitialFood);
        InitialGold = RemoteSettings.GetInt("initial_gold", _defaultInitialGold);

        WaterPerSecond = RemoteSettings.GetFloat("water_per_second", _defaultWaterPerSecond);
        FoodPerSecond = RemoteSettings.GetFloat("food_per_second", _defaultFoodPerSecond);
        GoldPerSecond = RemoteSettings.GetFloat("gold_per_second", _defaultGoldPerSecond);

        MaxWater = RemoteSettings.GetInt("max_water", _defaultMaxWater);
        MaxFood = RemoteSettings.GetInt("max_food", _defaultMaxFood);
        MaxGold = RemoteSettings.GetInt("max_gold", _defaultMaxGold);

        Initialized = true;
        RemoteSettings.Updated -= HandleRemoteUpdate;
    }

    private void UseLocalSettings()
    {
        InitialWater = _defaultInitialWater;
        InitialFood = _defaultInitialFood;
        InitialGold = _defaultInitialGold;

        WaterPerSecond = _defaultWaterPerSecond;
        FoodPerSecond = _defaultFoodPerSecond;
        GoldPerSecond = _defaultGoldPerSecond;

        MaxWater = _defaultMaxWater;
        MaxFood = _defaultMaxFood;
        MaxGold = _defaultMaxGold;

        Initialized = true;
    }
}
