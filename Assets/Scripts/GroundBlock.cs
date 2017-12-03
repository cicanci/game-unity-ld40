using UnityEngine;

public class GroundBlock : MonoBehaviour 
{
    [SerializeField] 
    private Material _selectedColor;

    [SerializeField] 
    private GameObject _playerArmyPrefab;

    [SerializeField] 
    private GameObject _enemyArmyPrefab;
    
    public int BlockId { set; get; }

    public void SelectBlock()
    {
        WorkerManager.Instance.ShowDefensePanel();
        GetComponent<MeshRenderer>().material = _selectedColor;
        
        GameObject block = Instantiate(_playerArmyPrefab);
        block.transform.parent = transform;
        block.transform.localPosition = new Vector3(0, 2, 0);
    }
}
