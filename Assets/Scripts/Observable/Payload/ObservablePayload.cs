using System;
using UnityEngine;

public abstract class ObservablePayload : EventArgs
{
    public Subject Subject { get; private set; }

    public ObservablePayload(Subject subject)
    {
        Subject = subject;
    }
}
