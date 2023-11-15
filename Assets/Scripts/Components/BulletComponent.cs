using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [Header("Travel Parameters")]
    public float travelSpeed = default;
    [SerializeField]private float bulletLifeTime = default;
    
    [Header("Bullet Damage")]
    public int damageValue = default;

    [Header("Towards Player Bullets")]
    [SerializeField] private bool curveTowardsPlayer = default;
    [SerializeField] private int rotation = default;
    private int rotationDirection = default;
    [SerializeField] private float rotateSpeed = default;

    private void OnEnable() {
        StartCoroutine(DeactivateObject());
        if (curveTowardsPlayer) rotationDirection = CurveBulletsTowardPlayer();
    }

    private void Update() {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * rotation * rotationDirection);

        float angleInDegrees = transform.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad));
        Vector2 newPosition = (Vector2)transform.position + direction * travelSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    IEnumerator DeactivateObject() {
        yield return new WaitForSeconds(bulletLifeTime);
        this.gameObject.SetActive(false);
    }

    private int CurveBulletsTowardPlayer()
    {
        if (this.gameObject.transform.position.x > GameManager.player.transform.position.x) return -1;
        else return 1;
    }
}
