using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3StateManager : MonoBehaviour
{
    Boss3BaseState currentState;
    public Boss3Phase1 phase1State = new Boss3Phase1();
    public Boss3Phase2 phase2State = new Boss3Phase2();

    HealthComponent healthComponent = default;

    private void Start() {
        currentState = phase1State;
        currentState.EnterState(this);

        healthComponent = GetComponent<HealthComponent>();
    }

    private void Update() {
        currentState.UpdateState(this);

        if (healthComponent.currentHealth > healthComponent.maxHealth /50) {
            SwitchState(phase2State);
        }
    }

    public void SwitchState(Boss3BaseState phase) {
        currentState = phase;
        phase.EnterState(this);
    }
}
