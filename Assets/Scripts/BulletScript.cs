using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Travel Properties")]
    [SerializeField]private float travelSpeed = default;
    [SerializeField]private float rotateSpeed = default;
    [SerializeField]private float bulletLifeTime = default;
    [Tooltip("Please only input -1, 0, or 1.")]
    [SerializeField]private int rotationDirection = default;

    private void Start() {
        Destroy(this.gameObject, bulletLifeTime);
    }

    private void Update() {
        transform.position += transform.up * travelSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * rotationDirection);
    }
}
