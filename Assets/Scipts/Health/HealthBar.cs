using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthBarFill;


    private void Start()
    {
        healthBarFill.fillAmount = health.currentHealth/health.maxHealth;
    }
    private void Update()
    {
        healthBarFill.fillAmount = health.currentHealth / health.maxHealth;
        
    }
}
