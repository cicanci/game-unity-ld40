using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] 
    private Material _selectedColor;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.GetComponent<MeshRenderer>().material = _selectedColor;
                }
            }
        }
    }
}
