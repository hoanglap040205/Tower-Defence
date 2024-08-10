using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private GameObject tower;
    private Color startColor;
    private void Start()
    {
        startColor = sr.color;

    }
    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sr.color = startColor;
    }
    private void OnMouseDown()
    {
        if (tower != null) return;
       
        Tower towerToBuild = BuildManager.main.GetSelectTurret();
        if(towerToBuild.cost > SconeManager.instance.coin)
        {
            Debug.Log("Khong du tien");
            return;
        }
        SconeManager.instance.SpendCoin(towerToBuild.cost);
        tower = Instantiate(towerToBuild.towerPrefab, transform.position, Quaternion.identity);
        
    }

}
