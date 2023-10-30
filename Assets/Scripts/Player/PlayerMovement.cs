using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float movementSpeed;

    private void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position -= transform.up * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position -= transform.right * movementSpeed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
