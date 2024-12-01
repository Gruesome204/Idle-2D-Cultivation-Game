using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
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

    private void Update()
    {

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
}