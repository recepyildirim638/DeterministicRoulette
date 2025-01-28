using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private Pool[] pools;
    public GameObject GetPoolItem(POOL_TYPE items)
    {
        Pool pool = GetPoolCell(items);
        GameObject resultObject = null;

        for (int i = 0; i < pool.poolObjects.Count; i++)
        {
            if (pool.poolObjects[i].gameObject.activeSelf == false)
            {
                resultObject = pool.poolObjects[i].gameObject;

                resultObject.SetActive(true);
                return resultObject;
            }
        }

        resultObject = Instantiate(pool.poolObjectPrefab, transform);
        resultObject.SetActive(true);
        pool.poolObjects.Add(resultObject);
        return resultObject;
    }

    Pool GetPoolCell(POOL_TYPE items)
    {
        if ((int)items > pools.Length)
            return pools[0];
        else
            return pools[(int)items];
    }


    [Serializable]
    struct Pool
    {
        public POOL_TYPE type;
        public GameObject poolObjectPrefab;
        public List<GameObject> poolObjects;
    }
}

