using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectsManager : MonoBehaviour
{
    public static SpawnedObjectsManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private List<GameObject> spawnedObjects = new List<GameObject>();


    public void AddObject(GameObject newObject) { spawnedObjects.Add(newObject); }

    public void DestroyObject()
    {
        foreach (GameObject spawnedObject in spawnedObjects)
        {
            Destroy(spawnedObject);
        }
    }

}
