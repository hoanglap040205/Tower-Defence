using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSlow : MonoBehaviour
{
    private float lifeTime;
    private Rigidbody2D body;
    private BoxCollider2D box;
    [SerializeField] private float speed = 8;
    private float direction;
    private Transform target;
    [SerializeField] private float amount;
    [SerializeField] private float duaration = 0.3f;
    [SerializeField] private float damge;
    private void Awake()
    {
        gameObject.SetActive(false);
        body = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        lifeTime += Time.deltaTime;
        if (lifeTime > 2)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        amount = Mathf.Clamp(amount,0, 1);
        lifeTime = 0;
        gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>()?.TakeDame(damge);
            collision.gameObject.GetComponent<Enemy>()?.Slow(amount,duaration);

        }
    }

    public void SetTarget(Transform _target)
    {
        lifeTime = 0;
        gameObject.SetActive(true);
        target = _target;
        Vector2 direc = (target.position - transform.position).normalized;
        RotateTowardTarget();
        body.velocity = direc * speed;
    }
    private void RotateTowardTarget()
    {
        Vector2 direc = (target.position - transform.position);
        float angle = Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg;
        Quaternion Rotate = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Rotate;
    }
}
