using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolComponent : MonoBehaviour
{
    [HideInInspector]public List<GameObject> pooledObjects = default;
    [SerializeField]private GameObject objectToPool = default;
    [SerializeField]private int amountToPool = default;
    [SerializeField]private Transform poolGroup = default;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject obj;
        for(int i = 0; i < amountToPool; i++)
        {
            obj = Instantiate(objectToPool, poolGroup);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
    {
        if(!pooledObjects[i].activeInHierarchy)
        {
            return pooledObjects[i];
        }
    }
        return null; 
        //this is intentional, I don't want the game to create any brand new objects if the pool runs out. -M
    }
}
