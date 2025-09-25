using UnityEngine;

public class CheckPoint : ObservableSubject
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false) return;
        Notify(new CheckPointPayload(transform.position, transform.rotation));
        gameObject.SetActive(false);
    }
}
