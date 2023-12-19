using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public static SpawnEnemies EnemyInstance;
    public List<GameObject> pooledEnemies;
    public GameObject objectToPool;
    public int amountToPool;

    public float spawnRangeX = 8;

    void Awake()
    {
        EnemyInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledEnemies = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledEnemies.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
        InvokeRepeating("SpawnPooledEnemy", 3, 1.5f);
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledEnemies list
        for (int i = 0; i < pooledEnemies.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    public void SpawnPooledEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 6, 0);

        // Get an object object from the pool
        GameObject pooledProjectile = EnemyInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true); // activate it
            pooledProjectile.transform.position = spawnPos; // position it at player
        }
    }
}
