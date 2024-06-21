using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldCanvasUI : MonoBehaviour
{
    public GameObject showText;
    public GameObject image;
    public GameObject finalText;
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
                finalText.SetActive(false);
                showText.SetActive(false);
                showText.SetActive(true);
                image.SetActive(false);
                transform.position = spawnPositions.panelStartPosition;
                break;

            case WorldCanvasState.IMAGE:
                finalText.SetActive(false);
                showText.SetActive(true);
                image.SetActive(false);
                image.SetActive(true);
                transform.position = spawnPositions.panelStartPosition;
                break;

            case WorldCanvasState.TELEPORT:
                image.SetActive(false);
                showText.SetActive(false);
                finalText.SetActive(true);
                transform.position = spawnPositions.sampleGLBSpawnPosition;
                transform.Translate(0, 5, 2F);
                break;

        }
    }

    private void EnableUI()
    {
        mainPanel.SetActive(true);
    }
}
