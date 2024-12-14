using Unity.Burst.CompilerServices;
using UnityEditor.PackageManager;
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
           //Interaction with Objects In Scene



        //Grab an Object
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == 6)
        {
            Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(grabbedObject == null)
                {
                    GrabObject(hitInfo);
                }
                else
                {
                    PlaceObject();
                }
            }
        }
    }

    public void GrabObject(RaycastHit2D hitInfo)
    {
        grabbedObject = hitInfo.collider.gameObject;
        grabbedObject.transform.SetParent(playerCharacter.transform);
        IsGrabbed = true;
        Debug.Log("Grab Object");
    }

    public void PlaceObject()
    {
        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
        IsGrabbed = false;

        Debug.Log("Place Object");
    }

}

