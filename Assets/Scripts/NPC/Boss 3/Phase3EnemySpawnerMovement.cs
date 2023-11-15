using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3EnemySpawnerMovement : MonoBehaviour
{
    void Update()
    {
        float horizontalpos = Random.Range(-8f, 8f);
        this.transform.position = new Vector3(horizontalpos, transform.position.y, transform.position.z);
    }
}
