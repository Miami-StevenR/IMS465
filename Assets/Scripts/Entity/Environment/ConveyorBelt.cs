using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : Conveyor
{
    [SerializeField] private float speed = 1.0f;
    private List<IEntity> _entities = new();
    public override void AttachEntity(IEntity entity)
    {
        _entities.Add(entity);
    }

    public override void DetachEntity(IEntity entity)
    {
        _entities.Remove(entity);
    }

    void FixedUpdate()
    {
        foreach (var entity in _entities) entity.Translate(transform.right * speed * Time.fixedDeltaTime);
    }
}
