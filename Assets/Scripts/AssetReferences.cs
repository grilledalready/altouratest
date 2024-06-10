using UnityEngine;

[CreateAssetMenu(fileName = "AssetReferences", menuName = "ScriptableObjects/AssetReferences", order = 1)]
public class AssetReferences : ScriptableObject
{
    public string videoPath;

    public string glbPath;
    public string[] glbTexturesPath;

    public string videoPrefabPath;
}