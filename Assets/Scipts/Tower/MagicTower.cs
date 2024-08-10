using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MagicTower : MonoBehaviour
{
    [SerializeField] private int targettingrage;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float bps = 1f;
    [SerializeField] private float damge = 0f;
    public GameObject[] magicBullet;
    private Transform target;
    private float cooldownFire;
    [SerializeField] Transform firePoint;
    void Start()
    {

    }
    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        
        if (!CheckTargetIsinRange())
        {
            target = null;
            return;
        }
        else
        {
            cooldownFire += Time.deltaTime;
            if (cooldownFire >= 1 / bps)
            {
                Shoot();
                cooldownFire = 0;
            }

        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, targettingrage, Vector2.zero, 0f, enemyMask);
        if (hit.Length > 0)
        {
            //Debug.Log("find");
            Array.Sort(hit, (a, b) => a.distance.CompareTo(b.distance));
            target = hit[0].transform;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, transform.forward, targettingrage);

    }
    private bool CheckTargetIsinRange()
    {
        return Vector2.Distance(transform.position, target.position) <= targettingrage;
    }

   

    private void Shoot()
    {
        magicBullet[FindMagicBullet()].transform.position = firePoint.position;
        magicBullet[FindMagicBullet()].GetComponent<MagicBullet>().Damge(damge);
        magicBullet[FindMagicBullet()].GetComponent<MagicBullet>().SetTarget(target);


    }


   private int FindMagicBullet()
    {


        for (int i = 0; i < magicBullet.Length; i++)
        {
            if (!magicBullet[i].activeInHierarchy)
            {
                return i;
            }
        }

        return -1;
    }


}

