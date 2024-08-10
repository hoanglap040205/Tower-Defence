using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.Experimental;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private float amountBullet = 15;
    [SerializeField] private GameObject bulletPrefab;
    private List<GameObject> poolObject = new List<GameObject>();


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for(int i = 0; i < amountBullet; i++)
        {
            GameObject objPool = Instantiate(bulletPrefab);
            objPool.SetActive(false);
            poolObject.Add(objPool);
        }
    }

    public GameObject GetPoolObj()
    {
        for(int i = 0; i < poolObject.Count; i++)
        {
            if (!poolObject[i].activeInHierarchy)
            {
                return poolObject[i];
            }
        }
        return null;
    }

}
