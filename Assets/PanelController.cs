using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public void Close()
    {
        UIManager.Instance.HandleMainScreen(true);
        Destroy(gameObject);
    }
}
