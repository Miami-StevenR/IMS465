using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Blob : MonoBehaviour, IEntity
{
    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Translate(Vector3 vector)
    {
        _rigidbody.MovePosition(transform.position + vector);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Conveyor"))
        {
            var conveyor = collision.gameObject.GetComponent<Conveyor>();
            AttachToConveyor(conveyor);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Conveyor"))
        {
            var conveyor = collision.gameObject.GetComponent<Conveyor>();
            DetachFromConveyor(conveyor);
        }
    }

    private void AttachToConveyor(IConveyor conveyor)
    {
        conveyor.AttachEntity(this);
    }

    private void DetachFromConveyor(IConveyor conveyor)
    {
        conveyor.DetachEntity(this);
    }
}
