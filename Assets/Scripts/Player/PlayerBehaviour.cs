using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    void Update()
    {
           
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit)
            {
                InteractWithObject(hit.collider.gameObject);
            }
        }
    }
    void InteractWithObject(GameObject objectToInteractWith)
    {
        if (objectToInteractWith.TryGetComponent(out IClickable clickableObject))
        {
            clickableObject.Interact();
        }
    }
}
