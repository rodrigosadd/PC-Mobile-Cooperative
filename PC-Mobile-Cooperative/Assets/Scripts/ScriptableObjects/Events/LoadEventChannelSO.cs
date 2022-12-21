using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Load Event Channel")]
public class LoadEventChannelSO : ScriptableObject
{
    public UnityAction<GameSceneSO, bool> OnLoadRequested;

    public void RaiseEvent(GameSceneSO gameSceneSO, bool showLoadingScreen = false)
    {
        if (OnLoadRequested != null)
        {
            OnLoadRequested.Invoke(gameSceneSO, showLoadingScreen);
        }
        else
        {
            Debug.LogWarning("Load Event Channel Null!!!");
        }
    } 
}
