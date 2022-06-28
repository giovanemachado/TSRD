using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class CutsceneState : BaseGameState
{
    public override void EnterState(GameManager gameManager)
    {
        gameManager.blockCam.SetActive(true);
        gameManager.player.SetActive(false);
        gameManager.StartCoroutine(FinishCut(gameManager));
    }

    IEnumerator FinishCut(GameManager gameManager)
    {
        yield return new WaitForSeconds(3);
        gameManager.player.SetActive(true);
        gameManager.blockCam.SetActive(false);

        if (GameManager.Instance.currentState == GameManager.Instance.CutsceneState)
        {
            GameManager.Instance.SwitchState(GameManager.Instance.PlayingState);
        }
    }
}
