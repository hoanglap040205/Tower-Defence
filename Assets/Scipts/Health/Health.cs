using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth { get; private set; }
    [SerializeField] private int blockDamge;
    [SerializeField] private int coinAmount;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            EnemySpawm.onEnemyDestroy.Invoke();
            SconeManager.instance.AddCoin(coinAmount);
            Destroy(gameObject);
        }
    }
    public void TakeDame(float damge)
    {
        float damage;
        damage = damge - blockDamge;
        if (damge < blockDamge)
        {
            damage = 1;
        }
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
    }

    public float GetHealth()
    {
        return (float)currentHealth / maxHealth;
    }
}
