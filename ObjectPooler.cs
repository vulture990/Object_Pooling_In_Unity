using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    
    [System.Serializable] 
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int numberOfSpawned;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDic;
    #region Singleton
    public static ObjectPooler instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    void Start()
    {
        poolDic = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> gameObjects = new Queue<GameObject>();
            for(int i=0;i<pool.numberOfSpawned;i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                gameObjects.Enqueue(obj);
            }
            poolDic.Add(pool.tag, gameObjects);
        }
    }
    public GameObject SpawnFromPool(string tag,Vector3 position,Quaternion rotation)
    {
        /*
        if(poolDic.ContainsKey(tag))
        {
            Debug.LogWarning("it doesn't exist x(");
            return null;
        }
        */
        GameObject objectToSpawn = new GameObject();
        objectToSpawn= poolDic[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if(pooledObj!=null)
        {
            pooledObj.OnObjSpawn();
        }
        poolDic[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
