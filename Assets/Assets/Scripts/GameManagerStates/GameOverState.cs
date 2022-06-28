using System.Collections;
using UnityEngine;

public class GameOverState : BaseGameState
{
    public override void EnterState(GameManager gameManager)
    {
        Debug.Log("Game over");
    }
}
