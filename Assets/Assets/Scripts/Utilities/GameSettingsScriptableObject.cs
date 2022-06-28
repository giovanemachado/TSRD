using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettingsScriptableObject : ScriptableObject
{
    [Header("Game")]
    public bool playingGame = false;
    public bool isGameOver = false;
    public float timeToGoBackGameArea = 0f;
    public bool shouldCountDown = false;

    [Header("Ship")]
    public bool shipCanMove = false;
    public float shipMoveDownAlwaysSpeed = 0.0f;

    public bool isMovingUp = false;
    public bool isMovingDown = false;
    public bool isTurningRight = false;
    public bool isTurningLeft = false;
    public bool isMovingToward = false;

    public bool isGrabbing = false;

    public float shipMoveUpSpeed = 0.0f;
    public float shipMoveDownSpeed = 0.0f;
    public float shipTurnRightSpeed = 0.0f;
    public float shipTurnLeftSpeed = 0.0f;
    public float shipMoveTowardSpeed = 0.0f;


    [Header("Building Generator")]
    public bool shouldGenerateANewBuilding = false;
    public float buildingRandomSizeInitial = 0f;
    public float buildingRandomSizeFinal = 0f;
    public float buildingRandomRotationInitial = 0f;
    public float buildingRandomRotationFinal = 0f;

    public void resetValues()
    {
        isGameOver = false;
        isMovingUp = false;
        isMovingDown = false;
        isTurningRight = false;
        isTurningLeft = false;
        isMovingToward = false;
        isGrabbing = false;
    }
}