using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [HideInInspector]public List<GameObject> pooledObjects;
    [SerializeField]private GameObject objectToPool;
    [SerializeField]private int amountToPool;
    [SerializeField]private Transform poolGroup;

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
    }
}
