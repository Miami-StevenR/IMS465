using UnityEngine;

public interface IObservableListener
{
    void OnReceieveMessage(object sender, ObservablePayload payload);
}
