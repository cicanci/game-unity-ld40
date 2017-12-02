using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _groundBlockPrefab;

    [SerializeField] 
    private Vector2 _boardSize;
    
    private void Start()
    {
        GameObject block = Instantiate(_groundBlockPrefab);
        
    }
}
