using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPartAreaController : MonoBehaviour
{
    public GameSettingsScriptableObject gameSettings;

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Block"))
        {
            gameSettings.shouldGenerateANewBuilding = true;
        }
    }
}
