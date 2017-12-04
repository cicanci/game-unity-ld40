using UnityEngine;

public class PlayerInput : MonoBehaviour
{
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
                    hit.rigidbody.GetComponent<GroundBlock>().SelectBlock();
                }
            }
        }
    }
}
