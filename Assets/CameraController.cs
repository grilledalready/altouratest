using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public SpawnPositions spawnPositions;
    private void OnEnable()
    {
        WorldCanvasController.OnStateChangedEvent += SetCameraPosition;
    }

    private void OnDisable()
    {
        WorldCanvasController.OnStateChangedEvent -= SetCameraPosition;
    }

    private void SetCameraPosition(WorldCanvasState currentState)
    {
        switch (currentState)
        {
            case WorldCanvasState.TEXT:
                transform.position = spawnPositions.playerStartPosition;
                break;

            case WorldCanvasState.IMAGE:
                transform.position = spawnPositions.playerStartPosition;
                break;

            case WorldCanvasState.TELEPORT:
                transform.position = spawnPositions.playerTeleportPosition;
                break;

        }
    }
}
