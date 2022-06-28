using UnityEngine;

public class QuitState : BaseGameState
{
    public override void EnterState(GameManager gameManager)
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
} 