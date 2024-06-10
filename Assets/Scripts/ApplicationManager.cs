using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public AssetReferences assetReferences;

    public static ApplicationManager instance;

    private void Awake()
    {
        instance = this;
    }
}
