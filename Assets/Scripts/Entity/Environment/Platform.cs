using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum PlatformDirection
{
    Forward = 1,
    Backward = -1
}

[RequireComponent(typeof(Rigidbody))]
public class Platform : Conveyor
{
    [SerializeField] private PlatformDirection direction = PlatformDirection.Forward;
    [SerializeField] private float speed = 1;

    private Rigidbody _rigidbody;
    private List<IEntity> _entities = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        var vector = (int)direction * speed * Time.fixedDeltaTime * Vector3.right;
        _rigidbody.MovePosition(transform.position + vector);
        foreach (var entity in _entities) entity.Translate(vector);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlatformBoundary"))
        {
            // Debug.Log("Entered a trigger!", other.gameObject);
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        direction = (PlatformDirection)((int)direction * -1);
        //Invoke(nameof(SwitchDirection), 3);
    }

    public override void AttachEntity(IEntity entity)
    {
        _entities.Add(entity);
    }

    public override void DetachEntity(IEntity entity)
    {
        _entities.Remove(entity);
    }
}
