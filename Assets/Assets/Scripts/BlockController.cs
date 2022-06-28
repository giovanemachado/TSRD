using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (
            collider.CompareTag("Block")
            || collider.CompareTag("ConstructionSite")
            || collider.CompareTag("BuildingTargetPlace")
            || collider.CompareTag("GetPartArea")
            || collider.CompareTag("ShipGrabArea")
        )
        {
            return;
        }

        GameManager.Instance.gameOverReason = "Um bloco caiu!";
        GameManager.Instance.SwitchState(GameManager.Instance.GameOverState);
    }
}
