using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Game Screen Bounds")]
    private Camera mainCamera;
    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;

    [Header("Movement Parameters")]
    [SerializeField]private float movementSpeed = default;
    [SerializeField]private float spinSpeed = default;
    [SerializeField]private Transform spriteTexture = default;
    int rotateDirection;

    private void Start() {
        CheckGameDimensions();
    }

    private void Update() {
        Movement(movementSpeed);
        StopObjectFromGoingOffScreen();
    }

    private void Movement(float movementSpeed) {
        int verticalInput = 0;
        int horizontalInput = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
            rotateDirection = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
            rotateDirection = 1;
        }

        Vector3 movementVector = new Vector3(horizontalInput, verticalInput, 0);
        movementVector.Normalize();
        transform.Translate(movementVector * movementSpeed * Time.deltaTime);
        spriteTexture.Rotate(0, 0, spinSpeed * Time.deltaTime * rotateDirection * -1);
    }

    private void CheckGameDimensions() {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    private void StopObjectFromGoingOffScreen() {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x + objectWidth / 2, screenBounds.x - objectWidth / 2);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y + objectHeight / 2, screenBounds.y - objectHeight / 2);
        transform.position = newPosition;
    }
}
