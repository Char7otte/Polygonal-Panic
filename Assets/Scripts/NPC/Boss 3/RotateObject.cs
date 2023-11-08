using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]private float rotateSpeed = default;

    private void Update() {
        if (Boss3PhaseManager.instance.phase2) {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }
}
