using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [Header("Travel Parameters")]
    [SerializeField]private float travelSpeed = default;
    [SerializeField]private float rotateSpeed = default;
    [SerializeField]private float bulletLifeTime = default;
    [Tooltip("Please only input -1, 0, or 1.")]
    [SerializeField]private int rotationDirection = default;
    
    [Header("Bullet Damage")]
    public int damageValue = default;

    [Header("Bullet Type")]
    [SerializeField]private bool[] bulletTypes;

    private void OnEnable() {
        StartCoroutine(DeactivateObject());
    }

    private void Update() {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * rotationDirection);

        float angleInDegrees = transform.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad));
        Vector2 newPosition = (Vector2)transform.position + direction * travelSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    IEnumerator DeactivateObject() {
        yield return new WaitForSeconds(bulletLifeTime);
        this.gameObject.SetActive(false);
    }
}
