using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldCanvasUI : MonoBehaviour
{
    public GameObject showText;
    public GameObject image;
    public GameObject mainPanel;

    public SpawnPositions spawnPositions;

    private void OnEnable()
    {
        WorldCanvasController.OnStateChangedEvent += DisplayUI;
        HomepageManager.OnGLBModeSetEvent += EnableUI;
    }

    private void OnDisable()
    {
        WorldCanvasController.OnStateChangedEvent -= DisplayUI;
        HomepageManager.OnGLBModeSetEvent -= EnableUI;
    }

    private void DisplayUI(WorldCanvasState currentState)
    {
        switch (currentState)
        {
            case WorldCanvasState.TEXT:
                showText.SetActive(true);
                image.SetActive(false);
                transform.position = spawnPositions.panelStartPosition;
                break;

            case WorldCanvasState.IMAGE:
                showText.SetActive(true);
                image.SetActive(true);
                transform.position = spawnPositions.panelStartPosition;
                break;

            case WorldCanvasState.TELEPORT:
                transform.position = spawnPositions.panelTeleportPosition;
                break;

        }
    }

    private void EnableUI()
    {
        mainPanel.SetActive(true);
    }
}
