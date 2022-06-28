using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameSettingsScriptableObject gameSettings;
    [HideInInspector] public bool thereIsBlockInRange = true;
    [HideInInspector] public bool thereIsBlockConnected;
    [HideInInspector] public GameObject block;

    public Transform buildingParent;
    public Transform grabParent;
    public Transform grabPosition;
    public GameObject detector;

    public bool FirstMove = false;

    Color red;
    Color green;

    Renderer detectorRenderer;

    public AudioSource turningMotor;
    public AudioSource motorOff;
    public AudioSource motorOn;
    public AudioSource goingUpMotor;
    public AudioSource goingDownMotor;
    public AudioSource turningBeep;
    public AudioSource grabOn;

    public GameObject motorVFX;

    private void Awake()
    {
        red = Color.red;
        red.a = 0.5f;

        green = Color.green;
        green.a = 0.5f;

        detectorRenderer = detector.GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        if (!thereIsBlockInRange)
        {
            detectorRenderer.material.color = red;
            detectorRenderer.material.SetColor("_EmissionColor", Color.red); 
        } else
        {
            detectorRenderer.material.color = green;
            detectorRenderer.material.SetColor("_EmissionColor", Color.green);
        }

        if (!FirstMove)
        {
            return;
        }

        if (!gameSettings.shipCanMove)
        {
            return;
        }

        if (gameSettings.isMovingUp)
        {
            MoveUp();
        } else
        {
            PlaySound(goingUpMotor, true);
        }
        
        if (gameSettings.isMovingDown)
        {
            MoveDown();
        } else
        {
            PlaySound(goingDownMotor, true);
        }

        if (gameSettings.isTurningLeft)
        {
            TurnLeft();
        } else if (gameSettings.isTurningRight)
        {
            TurnRight();
        } else
        {
            PlaySound(turningMotor, true);
            PlaySound(turningBeep, true);
        }

        if (gameSettings.isMovingToward)
        {
            MoveToward();

            if (!motorVFX.activeSelf)
            {
                motorVFX.SetActive(true);
            }
        }
        else {
            PlaySound(motorOn, true);
            PlaySound(motorOff);

            if (motorVFX.activeSelf)
            {
                motorVFX.SetActive(false);
            }
        }

        if (thereIsBlockInRange && !thereIsBlockConnected && gameSettings.isGrabbing)
        {
            GrabBlock(block);
            PlaySound(grabOn);
        }

        if (thereIsBlockConnected && !gameSettings.isGrabbing)
        {
            UngrabBlock(block);
            PlaySound(grabOn, true);
        }
    }

    void MoveUp()
    {
        PlaySound(goingUpMotor);

        transform.position = transform.position + (Vector3.up * (gameSettings.shipMoveUpSpeed * Time.deltaTime));
    }

    void MoveDown()
    {
        PlaySound(goingDownMotor);

        transform.position = transform.position + (Vector3.down * (gameSettings.shipMoveDownSpeed * Time.deltaTime));
    }

    void TurnRight()
    {
        PlaySound(turningMotor);
        PlaySound(turningBeep);

        transform.Rotate(Vector3.up * (gameSettings.shipTurnRightSpeed * Time.deltaTime));
    }

    void TurnLeft()
    {
        PlaySound(turningMotor);
        PlaySound(turningBeep);

        transform.Rotate(Vector3.down * (gameSettings.shipTurnRightSpeed * Time.deltaTime));
    }

    void MoveToward()
    {
        PlaySound(motorOn);
        PlaySound(motorOff, true);
      
        transform.position = transform.position + (transform.forward * (gameSettings.shipMoveTowardSpeed * Time.deltaTime));
    }

    void PlaySound(AudioSource audio, bool shouldTurnOff = false)
    {
        if (shouldTurnOff)
        {
            audio.Stop();
            return;
        }

        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }

    void GrabBlock(GameObject physicBlock)
    {
        Rigidbody rb = physicBlock.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        GameObject parentBlock = physicBlock.transform.parent.gameObject;
        parentBlock.transform.parent = grabParent;

        thereIsBlockConnected = true;
    }

    void UngrabBlock(GameObject physicBlock)
    {
        GameObject parentBlock = physicBlock.transform.parent.gameObject;

        Rigidbody rb = physicBlock.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        parentBlock.transform.parent = buildingParent;
        thereIsBlockConnected = false;

        GameManager.Instance.currentBlock = physicBlock;
        GameManager.Instance.SwitchState(GameManager.Instance.CutsceneState);
    }
}
