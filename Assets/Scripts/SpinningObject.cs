using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    [Tooltip("How much the object will spin in 1 second.")]
    [SerializeField]private float playerSpinSpeed = default;
    
    [Tooltip("Currently unused.")]
    [SerializeField]private bool isClockwiseSpinDirection = default;

    private void Update() {
        SpinObject(playerSpinSpeed, isClockwiseSpinDirection);
    }

    private void SpinObject(float spinSpeed, bool isClockwise) {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
