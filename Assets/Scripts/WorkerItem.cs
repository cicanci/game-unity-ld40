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
        _currentAmount++;
        _amountText.text = _currentAmount + "";
    }

    public void RemoveWorker()
    {
        _currentAmount--;
        _amountText.text = _currentAmount + "";
    }
}
