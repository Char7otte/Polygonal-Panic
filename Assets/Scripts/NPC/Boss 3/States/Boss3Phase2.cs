using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Phase2 : Boss3BaseState
{
    public override void EnterState(Boss3StateManager phase) {
        Debug.Log("Phase 2 started.");
    }

    public override void UpdateState(Boss3StateManager phase) {
        
    }
}
