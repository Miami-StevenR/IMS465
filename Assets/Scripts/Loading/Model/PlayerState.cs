using System;
using UnityEngine;

[Serializable]
public class SerializablePlayerState
{
    public Vector3 Position;
    public Quaternion Rotation;
}

public class PlayerState
{
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }

    public PlayerState()
    {
        
    }
    public PlayerState(SerializablePlayerState serialized)
    {
        Position = serialized.Position;
        Rotation = serialized.Rotation;
    }

    public void UpdateFromCheckpoint(CheckPointPayload checkpoint)
    {
        Position = checkpoint.Position;
        Rotation = checkpoint.Rotation;
    }

    public SerializablePlayerState AsSerializable()
    {
        return new SerializablePlayerState()
        {
            Position = Position,
            Rotation = Rotation
        };
    }
}
