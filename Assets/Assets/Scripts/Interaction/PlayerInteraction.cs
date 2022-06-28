using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInteraction : MonoBehaviour
{
    public ShipController shipController;
    public float interactionDistance;

    string interactionText = "Pressione [E]";

    public TMPro.TextMeshProUGUI upDownInteractionText;
    public TMPro.TextMeshProUGUI turnInteractionText;
    public TMPro.TextMeshProUGUI motorInteractionText;
    public TMPro.TextMeshProUGUI grabInteractionText;

    public AudioSource defaultAudioSource;
    public AudioClip lever1Sound;
    public AudioClip lever2Sound;
    public AudioClip buttonSound;

    AudioClip audioToPlay;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                if (interactable.CompareTag("GoUpButton"))
                {
                    HandleInteraction(interactable);
                    upDownInteractionText.text = interactionText;
                    successfulHit = true;
                    audioToPlay = lever1Sound;
                }

                if (interactable.CompareTag("TurnRightButton"))
                {
                    HandleInteraction(interactable);
                    turnInteractionText.text = interactionText;
                    successfulHit = true;
                    audioToPlay = lever2Sound;
                }

                if (interactable.CompareTag("TurnOnMotorButton"))
                {
                    HandleInteraction(interactable);
                    motorInteractionText.text = interactionText;
                    successfulHit = true;
                    audioToPlay = buttonSound;
                }

                if (interactable.CompareTag("GrabUngrabButton"))
                {
                    if (shipController.thereIsBlockInRange)
                    {
                        HandleInteraction(interactable);
                        grabInteractionText.text = interactionText;
                        audioToPlay = buttonSound; 
                        successfulHit = true;
                    } else
                    {
                        grabInteractionText.text = "Sem blocos para carregar.";
                        successfulHit = true;
                    }
                }
            }
        }

        if (!successfulHit)
        {
            upDownInteractionText.text = "";
            turnInteractionText.text = "";
            motorInteractionText.text = "";
            grabInteractionText.text = "";
        }
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    if (!shipController.FirstMove)
                    {
                        shipController.FirstMove = true;
                    }

                    defaultAudioSource.PlayOneShot(audioToPlay);

                    interactable.Interact();
                }
                break;
        }
    }



    private void OnDrawGizmosSelected()
    {
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        Gizmos.color = transparentRed;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), interactionDistance);
    }
}

