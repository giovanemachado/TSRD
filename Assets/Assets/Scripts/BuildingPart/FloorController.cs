using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameSettingsScriptableObject gameSettings;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Block"))
        {
            GameManager.Instance.gameOverReason = "Um bloco caiu!";
            GameManager.Instance.SwitchState(GameManager.Instance.GameOverState);
        }
    }
}
