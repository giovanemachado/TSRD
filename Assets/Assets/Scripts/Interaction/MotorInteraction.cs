using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorInteraction : Interactable 
{ 
    public bool isOn = false;

    public bool interactionToCheck;

    public GameSettingsScriptableObject gameSettings;
    Animator animator;

    private void Awake()
    {
        Transform child = transform.Find("MotorButton");
        animator = child.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!interactionToCheck)
        {
            return;
        }

        interactionToCheck = false;

        gameSettings.isMovingToward = isOn;
        PressButton(isOn);
    }

    public override void Interact()
    {
        interactionToCheck = true;

        isOn = !isOn;
    }

    void PressButton(bool isPressed)
    {
        animator.SetBool("ButtonIsPressed", isPressed);
    }
}

