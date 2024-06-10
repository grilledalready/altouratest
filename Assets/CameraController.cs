using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
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
                transform.position = new Vector3(-0.75F, 0.5F, -1.5F);
                break;

            case WorldCanvasState.IMAGE:
                transform.position = new Vector3(-0.75F, 0.5F, -1.5F);
                break;

            case WorldCanvasState.TELEPORT:
                transform.position = new Vector3(0.75F, 0.5F, -1.5F);
                break;

        }
    }
}
