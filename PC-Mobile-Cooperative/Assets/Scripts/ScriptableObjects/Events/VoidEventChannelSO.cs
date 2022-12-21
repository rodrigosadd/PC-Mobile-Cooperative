using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnVoidRequested;

    public void RaiseEvent()
    {
        if (OnVoidRequested != null)
        {
            OnVoidRequested.Invoke();
        }
        else
        {
            Debug.LogWarning("Void Event Channel Null!!!");
        }
    }
}
