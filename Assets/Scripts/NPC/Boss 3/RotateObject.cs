using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]private float rotateSpeed = default;

    private void Update() {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);   
    }
}
