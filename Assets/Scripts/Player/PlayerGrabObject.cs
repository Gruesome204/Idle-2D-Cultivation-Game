using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerGrabObject : MonoBehaviour
{

    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;

    [SerializeField] private GameObject grabbedObject;
    [SerializeField] private GameObject playerCharacter;

    [SerializeField] private bool IsGrabbed;

    private void Start()
    {
        rayDistance = 0.1f;
        IsGrabbed = false;
    }



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



        //Grab an Object
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == 6)
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrabbed == false)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.transform.SetParent(playerCharacter.transform);
                IsGrabbed = true;
                Debug.Log("Grab Object");
            }
            else if (Input.GetKeyDown(KeyCode.Space) && IsGrabbed == true)
            {
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                IsGrabbed = false;

                Debug.Log("Place Object");
            }
        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }

    void InteractWithObject(GameObject objectToInteractWith)
    {
        if (objectToInteractWith.TryGetComponent(out IClickable clickableObject))
        {
            clickableObject.Interact();
        }
    }
}

