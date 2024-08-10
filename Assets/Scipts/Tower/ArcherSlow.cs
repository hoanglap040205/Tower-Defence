using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArcherSlow : MonoBehaviour
{
    [SerializeField] private int targettingrage;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float bps = 1f;
    public GameObject[] arrowSlow;
    private Transform target;
    private float cooldownFire;
    [SerializeField] Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/
        if (target == null)
        {
            FindTarget();
            return;
        }
        Flip();
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

    private void Flip()
    {
        if (transform.position.x - target.position.x > 0.01f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position.x - target.position.x < -0.1f)
        {
            transform.localScale = Vector2.one;
        }
    }

    private void Shoot()
    {
        arrowSlow[FindArrow()].transform.position = firePoint.position;
        arrowSlow[FindArrow()].GetComponent<ArrowSlow>().SetTarget(target);

    }

    private int FindArrow()
    {


        for (int i = 0; i < arrowSlow.Length; i++)
        {
            if (!arrowSlow[i].activeInHierarchy)
            {
                return i;
            }
        }

        return -1;
    }
}
