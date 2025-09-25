using UnityEngine;

public abstract class Conveyor : MonoBehaviour, IConveyor
{
    public abstract void AttachEntity(IEntity entity);

    public abstract void DetachEntity(IEntity entity);
}