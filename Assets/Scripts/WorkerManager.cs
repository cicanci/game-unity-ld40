using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public static WorkerManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
        HideDefensePanel();
    }

    public void ShowDefensePanel()
    {
        gameObject.SetActive(true);
    }

    public void HideDefensePanel()
    {
        gameObject.SetActive(false);
    }
}
