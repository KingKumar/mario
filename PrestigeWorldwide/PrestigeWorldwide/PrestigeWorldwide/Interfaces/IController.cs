using System;
using System.Collections;

public interface IController
{
    // Properties
    ArrayList PastState { get; }
    ArrayList CurrentState { get; }

    void Update();
}

