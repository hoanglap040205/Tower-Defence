using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SconeManager : MonoBehaviour
{
    public static SconeManager instance;
    public int countEnemyDesTroy;
    public int coin;
    [SerializeField] private int startCoin = 100;
    public  Transform startPoint;
    public Transform[] path;
    private void Start()
    {
        coin = startCoin;
    }
    private void Awake()
    {
        instance = this;
        
    }
    private void Update()
    {
        if (countEnemyDesTroy > 2)
        {
          //  Debug.Log("thua roi");
        }
    }
    public void AddCoin(int amount)
    {
        coin += amount;
    }
    public bool SpendCoin(int amount)
    {
        if(amount <= coin)
        {
            coin -= amount;
            return true;
        }
        else { return false; }
    }
}
