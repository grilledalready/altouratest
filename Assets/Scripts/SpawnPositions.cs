using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPositions", menuName = "ScriptableObjects/SpawnPositions", order = 1)]
public class SpawnPositions : ScriptableObject
{
    public Vector3 playerStartPosition;
    public Vector3 panelStartPosition;

    public Vector3 playerTeleportPosition;
    public Vector3 panelTeleportPosition;

    public Vector3 sampleGLBSpawnPosition;
    public Vector3 sampleGLBSpawnScale;

}