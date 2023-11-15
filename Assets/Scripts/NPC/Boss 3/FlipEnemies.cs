using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemies : MonoBehaviour
{

    private void Update() {
        if (Boss3PhaseManager.instance.phase3ExitTimer < 10) {
            GetComponent<BulletComponent>().travelSpeed *= -1;
            enabled = false;
        }
    }
}
