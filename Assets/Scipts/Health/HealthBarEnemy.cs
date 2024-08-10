using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] Transform healthBar;
    private void Update()
    {
        healthBar.localScale = new Vector3(health.GetHealth(), 1, 1);
    }
}
