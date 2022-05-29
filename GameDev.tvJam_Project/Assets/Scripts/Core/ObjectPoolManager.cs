using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDic; 
    
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size; 
    }

    [SerializeField] List<Pool> pools;
    public static ObjectPoolManager Instance;

    private void Awake()
    {
        Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePools();
    }

    private void CreatePools()
    {
        poolDic = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            if (poolDic.ContainsKey(pool.tag))
            {
                Debug.LogError("Repeated tag in pools list!");
            }
            else
            {
                Queue<GameObject> objPool = new Queue<GameObject>(); 
                for(int i=0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab, transform.position, pool.prefab.transform.rotation);
                    obj.SetActive(false);
                    objPool.Enqueue(obj); 
                }
                poolDic.Add(pool.tag, objPool); 
            }
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, bool origRotation)
    {
        if (!poolDic.ContainsKey(tag))
        {
            Debug.LogError("Tag " + tag + " doesn't exist!");
            return null;
        }
        Debug.Log("tag + count: " + tag + " - " + poolDic[tag].Count); 
        GameObject obj = poolDic[tag].Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        if (!origRotation) { obj.transform.rotation = rotation; }
        poolDic[tag].Enqueue(obj);
        return obj; 
    }
}
