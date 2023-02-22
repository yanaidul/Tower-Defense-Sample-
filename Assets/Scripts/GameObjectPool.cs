using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    public static GameObjectPool s_sharedInstance;
    private List<GameObject> pooledObjects;
    public GameObject[] objectsToPool;
    public int amountToPool;

    private int currentIndex;

    void Awake()
    {
        s_sharedInstance = this;
        currentIndex = 0;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            int random = Random.Range(0, objectsToPool.Length);
            tmp = Instantiate(objectsToPool[random]);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && i == currentIndex)
            {
                currentIndex++;
                if (currentIndex == amountToPool - 1) currentIndex = 0;
                return pooledObjects[i];
            }
        }
        return null;
    }
}
