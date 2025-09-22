using System;
using UnityEngine;

public class CheckPointPayload : ObservablePayload
{
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }

    public CheckPointPayload(Vector3 position, Quaternion rotation) : base(Subject.Checkpoint)
    {
        Position = position;
        Rotation = rotation;
    }
}
