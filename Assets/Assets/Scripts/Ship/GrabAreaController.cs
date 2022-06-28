using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAreaController : MonoBehaviour
{
    public GameObject ship;
    ShipController shipController;

    private void Awake()
    {
        shipController = ship.GetComponent<ShipController>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Block"))
        {
            shipController.block = collider.gameObject;
            shipController.thereIsBlockInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Block"))
        {
            shipController.block = collider.gameObject;
            shipController.thereIsBlockInRange = false;
        }
    }
}
