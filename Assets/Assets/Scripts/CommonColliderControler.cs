using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonColliderControler : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Decoration"))
        {
            GameManager.Instance.gameOverReason = "O transportador arranhou em algo!";
            GameManager.Instance.SwitchState(GameManager.Instance.GameOverState);
        }
    }
}
