using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    private struct PooledObject
    {
        public Zombie prefab;
        public int numToSpawn;
    }

    [SerializeField] private PooledObject[] pools;

    private static readonly Dictionary<string, Queue<Zombie>> pooledObjects = new Dictionary<string, Queue<Zombie>>();

    private void Awake()
    {
        pooledObjects.Clear();

        foreach (PooledObject pool in pools)
        {
            string name = pool.prefab.name;
            Transform parent = new GameObject(name).transform;
            parent.SetParent(transform);
            Queue<Zombie> objectsToSpawn = new(pool.numToSpawn);
            for (int i = 0; i < pool.numToSpawn; i++)
            {
                Zombie rb = Instantiate(pool.prefab, parent);
                rb.gameObject.SetActive(false);
                objectsToSpawn.Enqueue(rb);
            }

            pooledObjects.Add(name, objectsToSpawn);
        }
    }

    public static Zombie CreateEnemy(string name, Vector3 location, Quaternion rotation)
    {
        if (!pooledObjects.ContainsKey(name))
        {
            Debug.LogAssertion("Pool does not contain key: " + name);
            return null;
        }

        Zombie rb = pooledObjects[name].Dequeue();

        rb.transform.SetPositionAndRotation(location, rotation);
        rb.gameObject.SetActive(true);

        pooledObjects[name].Enqueue(rb);
        return rb;
    }
}
