using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "ScriptableObjects/GameScene")]
public class GameSceneSO : ScriptableObject
{
    public AssetReference sceneReference;
}
