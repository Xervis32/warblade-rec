using System.Collections.Generic;
using UnityEngine;

public class PLayerBulletsPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private int poolSize;
    private List<GameObject> pool;

    void Start()
    {
        poolSize = PlayerController.Instance.bullets;
        CreatePool();
    }

    private void CreatePool()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    private void CreateNewObject()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        pool.Add(obj);
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                return obj;
            }
        }
        return null;
    }
}
