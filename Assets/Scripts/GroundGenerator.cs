using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _groundBlockPrefab;

    [SerializeField]
    private Vector2 _boardSize;

    [SerializeField]
    private Vector3 _initialPosition;

    [SerializeField]
    private float _spaceOffset;

    private void Start()
    {
        GenerateGround();
    }

    private void GenerateGround()
    {
        for(int i = 0; i < _boardSize.x; i++)
        {
            for(int j = 0; j < _boardSize.y; j++)
            {
                GameObject block = Instantiate(_groundBlockPrefab);
                block.transform.parent = transform;

                Vector3 position = block.transform.localPosition - _initialPosition;
                block.transform.localPosition = new Vector3(
                    position.x + (i * _spaceOffset),
                    position.y,
                    position.z + (j * _spaceOffset));
            }
        }
    }
}
