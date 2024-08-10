using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float fixSpeed;
    private float moveSpeed;
    private Rigidbody2D body;
    private Transform target;
    private int index = 0;
    private bool isSlow = false;
    

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        target = SconeManager.instance.path[index];
        moveSpeed = fixSpeed;
    }
    private void Update()
    {
        Flip();
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            index = index + 1;
            if(index == SconeManager.instance.path.Length)
            {
                
                SconeManager.instance.countEnemyDesTroy++;
                EnemySpawm.onEnemyDestroy.Invoke();
                Destroy(gameObject);
            }
            else
            {
                target = SconeManager.instance.path[index];
            }
        }
        

    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        
        body.velocity = direction * fixSpeed;
    }
     public void Slow(float amount, float duration)
    {
        if (isSlow) return;
        fixSpeed = fixSpeed * amount;
        isSlow = true;
        StartCoroutine(ResetSpeed(duration));

    }

    private IEnumerator ResetSpeed(float duration)
    {
        yield return new WaitForSeconds(duration);
        fixSpeed = moveSpeed;
        isSlow = false;
    }


    private void Flip()
    {
        if(target.position.x- transform.position.x < 0)
        {
            transform.localScale = new Vector2(-1,1);
        }else if(target.position.x  - transform.position.x> 0)
        {
            transform.localScale = Vector2.one;
        }
    }
    
}
