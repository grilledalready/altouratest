using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorldCanvasState
{
    TEXT,
    IMAGE,
    TELEPORT
}

public class WorldCanvasController : MonoBehaviour
{
    public delegate void WorldCanvasControllerEventHandler(WorldCanvasState currentState);
    public static event WorldCanvasControllerEventHandler OnStateChangedEvent;

    public WorldCanvasState state;

    public void NextState()
    {
        state = (WorldCanvasState)(((int)state + 1) % System.Enum.GetValues(typeof(WorldCanvasState)).Length);

        OnStateChangedEvent?.Invoke(state);
    }

    public void PreviousState()
    {
        state = (WorldCanvasState)(((int)state - 1 + System.Enum.GetValues(typeof(WorldCanvasState)).Length) % System.Enum.GetValues(typeof(WorldCanvasState)).Length);

        OnStateChangedEvent?.Invoke(state);
    }
}
