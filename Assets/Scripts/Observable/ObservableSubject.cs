using System;
using UnityEngine;

public class ObservableSubject : MonoBehaviour
{
    private event EventHandler<ObservablePayload> notify;

    public void AddListener(IObservableListener listener)
    {
        notify += listener.OnReceieveMessage;
    }

    public void RemoveListener(IObservableListener listener)
    {
        notify -= listener.OnReceieveMessage;
    }

    protected void Notify(ObservablePayload payload)
    {
        notify?.Invoke(this, payload);
    }
}
