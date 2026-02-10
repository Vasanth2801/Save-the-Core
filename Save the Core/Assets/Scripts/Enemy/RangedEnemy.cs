using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Chasing settings")]
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] Transform target;
    [SerializeField] float rotationSpeed = 0.0025f;
    [SerializeField] float bulletForce = 7f;

    [Header("References")]
    private Rigidbody2D rb;
    [SerializeField] private Objectpooler pooler;

    [Header("Distance for the enemy to shoot")]
    [SerializeField] float distanceToShoot = 5f;
    [SerializeField] float distanceToStop = 2f;

    [Header("Firing rate for the enemy")]
    [SerializeField] float fireRate;
    [SerializeField] float timer = 0;

    [Header("References for bullet and fire point ")]
    [SerializeField] Transform firePoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = fireRate;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pooler = FindObjectOfType<Objectpooler>();
    }

    private void Update()
    {
        if (target == null)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if (Vector2.Distance(transform.position, target.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (timer <= 0)
        {
            GameObject bullet = pooler.SpawnFromPools("EnemyBullet", firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
            timer = fireRate;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) >= distanceToStop)
        {
            rb.linearVelocity = transform.up * enemySpeed * Time.fixedDeltaTime;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void RotateTowardsTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }
}
