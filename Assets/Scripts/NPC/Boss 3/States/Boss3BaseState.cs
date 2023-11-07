using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss3BaseState
{
    public abstract void EnterState(Boss3StateManager phase);
    public abstract void UpdateState(Boss3StateManager phase);
}
