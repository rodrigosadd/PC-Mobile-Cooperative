using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class InitializationLoader : MonoBehaviour
{
    [SerializeField] private GameSceneSO _managersScene;
    [SerializeField] private GameSceneSO _mainMenuScene;

    [Header("Broadcasting on")]
    [SerializeField] private AssetReference _menuLoadChannel;

    void Start()
    {
        _managersScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadEventChannel;
    }

    void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
    {
        _menuLoadChannel.LoadAssetAsync<LoadEventChannelSO>().Completed += LoadMainMenu;
    }

    void LoadMainMenu(AsyncOperationHandle<LoadEventChannelSO> obj)
    {
        obj.Result.RaiseEvent(_mainMenuScene, true);

        SceneManager.UnloadSceneAsync(0);
    }
}
