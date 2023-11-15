using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase4Shooting : MonoBehaviour
{
    ObjectPoolComponent objectPoolComponent = default;
    [SerializeField]private bool startedCoroutine = false;
    [SerializeField]private Transform bulletSpawnLocation = default;
    [SerializeField]private float fireRate = default;
    [Tooltip("How many bullets will be fired in a 360 cycle. Or something. Idk how to explain. It's 2 a.m.")]
    [SerializeField]private int numberOfRotations = default;
    
    private void Start()
    {
        objectPoolComponent = GetComponent<ObjectPoolComponent>();
    }

    private void Update()
    {
        if (!startedCoroutine) StartCoroutine(Shoot(fireRate, bulletSpawnLocation));
    }

    private void InstantiateBullet(Transform bulletSpawnPosition) {
        GameObject bullet = objectPoolComponent.GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = bulletSpawnPosition.position;
            bullet.transform.rotation = bulletSpawnPosition.rotation;
            bullet.SetActive(true);
        }
    }

    IEnumerator Shoot(float _fireRate, Transform _bulletSpawnLocation) {
        startedCoroutine = true;

        var angleToMove = 360 / numberOfRotations;

        for (int i = 0; i < numberOfRotations; i++) {
            _bulletSpawnLocation.Rotate(0, 0, angleToMove);  
            InstantiateBullet(_bulletSpawnLocation);
            yield return new WaitForSeconds(_fireRate);
        }

        startedCoroutine = false;
    }
}
