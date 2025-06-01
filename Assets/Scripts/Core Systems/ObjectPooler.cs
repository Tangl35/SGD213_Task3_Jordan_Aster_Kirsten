using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ObjectPool = new List<GameObject>();
    [SerializeField]
    private GameObject prefab;

    //Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.SetActive(false);

            ObjectPool.Add(newObject);
        }
    }
    public GameObject GetObjectFromPool()
    {
        if (ObjectPool.Count == 0)
        {
            return null;
        }

        GameObject obj = ObjectPool[0];
        ObjectPool.Remove(obj);
        return obj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        ObjectPool.Add(obj);
    }
}
