using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]private float travelSpeed;

    private void Update() {
        transform.position += transform.up * travelSpeed * Time.deltaTime;
    }
}
