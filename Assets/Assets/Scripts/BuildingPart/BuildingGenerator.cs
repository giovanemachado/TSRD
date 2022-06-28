using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameSettingsScriptableObject gameSettings;
    public GameObject[] buildingParts;
    public GameObject ship;

    private ShipController shipController;

    private void Awake()
    {
        shipController = ship.GetComponent<ShipController>();
    }

    void Update()
    {
        if (gameSettings.shouldGenerateANewBuilding && !shipController.thereIsBlockConnected)
        {
            CreateNewBuildingPart();
        }
    }

    public void CreateNewBuildingPart()
    {
        GameObject randomBuilding = buildingParts[Random.Range(0, buildingParts.Length)];

        float scaleRandom = Random.Range(gameSettings.buildingRandomSizeInitial, gameSettings.buildingRandomSizeFinal);
        randomBuilding.transform.localScale = new Vector3(scaleRandom, scaleRandom, scaleRandom);

        Vector3 randomRotation = new Vector3(0, Random.Range(gameSettings.buildingRandomRotationInitial, gameSettings.buildingRandomRotationFinal), 0);
       
        GameObject buildingPart = Instantiate(randomBuilding, transform);
        buildingPart.transform.Rotate(randomRotation);

        gameSettings.shouldGenerateANewBuilding = false;
    }
}
