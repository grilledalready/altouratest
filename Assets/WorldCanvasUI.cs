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
                transform.position = new Vector3(-0.75F, 0, 0);
                break;

            case WorldCanvasState.IMAGE:
                showText.SetActive(true);
                image.SetActive(true);
                transform.position = new Vector3(-0.75F, 0, 0);
                break;

            case WorldCanvasState.TELEPORT:
                transform.position = new Vector3(0.75F, 0, 0);
                break;

        }
    }

    private void EnableUI()
    {
        mainPanel.SetActive(true);
    }
}
