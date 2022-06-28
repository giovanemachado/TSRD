
public class PlayingState : BaseGameState
{
    public override void EnterState(GameManager gameManager) {
        if (!gameManager.alreadyShowIntro)
        {
            DialogueManager d = gameManager.dialogueManager.GetComponent<DialogueManager>();
            d.StartDialogue();
            gameManager.alreadyShowIntro = true;
        }

        gameManager.gameSettings.resetValues();
    }
} 