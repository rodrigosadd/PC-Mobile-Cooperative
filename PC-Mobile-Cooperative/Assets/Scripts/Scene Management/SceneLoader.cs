using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEditor.AddressableAssets.Build;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingCanvas;
    [SerializeField] private Image _loadingFill;

    [SerializeField] private LoadEventChannelSO _menuLoadChannel;

    private AsyncOperationHandle<SceneInstance> _loadingOperationHandle;
    private float _percentCompleteScene;
    private bool _canUpdateloadingFill;

    private void OnEnable()
    {
        _menuLoadChannel.OnLoadRequested += LoadScene;
    }

    private void OnDisable()
    {
        _menuLoadChannel.OnLoadRequested -= LoadScene;
    }
    
    public async void LoadScene(GameSceneSO scene, bool showLoadingScreen)
    {
        _percentCompleteScene = 0f;
        _loadingFill.fillAmount = 0f;
        _canUpdateloadingFill = true;

        _loadingOperationHandle = scene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, false);        
        _loadingCanvas.SetActive(showLoadingScreen);

        do
        {
            _percentCompleteScene = _loadingOperationHandle.PercentComplete;
        } while (_loadingOperationHandle.PercentComplete < 0.9f);

        await Task.Delay(1000);

        _loadingOperationHandle.Completed += LoadingCompleted;        
    }

    void LoadingCompleted(AsyncOperationHandle<SceneInstance> obj)
    {
        obj.Result.ActivateAsync();
        _loadingCanvas.SetActive(false);
        _canUpdateloadingFill = false;
    }

    private void Update()
    {
        if (_canUpdateloadingFill)
        {
            _loadingFill.fillAmount = Mathf.MoveTowards(_loadingFill.fillAmount, _percentCompleteScene, 3f * Time.deltaTime);
        }
    }
}
