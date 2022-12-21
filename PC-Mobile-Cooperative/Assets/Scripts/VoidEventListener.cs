using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    public VoidEventChannelSO voidEventChannelSO;

    public UnityEvent OnEventRised;

    private void Start()
    {
        voidEventChannelSO.OnVoidRequested += RiseEvent;
    }

    void RiseEvent()
    {
        if (OnEventRised == null)
            return;

        OnEventRised.Invoke();
    }

    public void Exit()
    {
        Debug.Log("JOGO FECHOU!!! ");
    }
}
