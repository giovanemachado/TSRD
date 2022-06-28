using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUpInteraction : Interactable
{
    enum MovementEnum
    {
        UP,
        DOWN,
        STOPPED
    }

    MovementEnum currentMovement = MovementEnum.STOPPED;
    MovementEnum lastMovement = MovementEnum.DOWN;
    MovementEnum nextMovement = MovementEnum.UP;

    public bool interactionToCheck;

    public GameSettingsScriptableObject gameSettings;
    Animator animator;

    private void Awake()
    {
        Transform child = transform.Find("UpDownLever");
        animator = child.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!interactionToCheck)
        {
            return;
        }

        interactionToCheck = false;

        if (nextMovement == MovementEnum.STOPPED)
        {
            gameSettings.isMovingUp = false;
            gameSettings.isMovingDown = false;

            MoveLeverDownAnim(false);
            MoveLeverUpAnim(false);
        } else if (nextMovement == MovementEnum.UP) 
        {
            gameSettings.isMovingUp = true;
            gameSettings.isMovingDown = false;

            MoveLeverUpAnim(true);
        }
        else if (nextMovement == MovementEnum.DOWN) 
        {
            gameSettings.isMovingUp = false;
            gameSettings.isMovingDown = true;

            MoveLeverDownAnim(true);
        }

        lastMovement = currentMovement;
        currentMovement = nextMovement; 
    }

    public override void Interact()
    {
        interactionToCheck = true;

        if (lastMovement == MovementEnum.DOWN && currentMovement == MovementEnum.STOPPED)
        {
            nextMovement = MovementEnum.UP;
        }

        if (lastMovement == MovementEnum.STOPPED && currentMovement == MovementEnum.UP)
        {
            nextMovement = MovementEnum.STOPPED;
        }

        if (lastMovement == MovementEnum.UP && currentMovement == MovementEnum.STOPPED)
        {
            nextMovement = MovementEnum.DOWN;
        }

        if (lastMovement == MovementEnum.STOPPED && currentMovement == MovementEnum.DOWN)
        {
            nextMovement = MovementEnum.STOPPED;
        }
    }

    void MoveLeverUpAnim(bool isUp)
    {
        animator.SetBool("MoveLeverUp", isUp);
    }

    void MoveLeverDownAnim(bool isDown)
    {
        animator.SetBool("MoveLeverDown", isDown);
    }
}
