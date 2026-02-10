using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    public Transform firePoint;
    public float bulletForce = 20f;

    [Header("references")]
    public Objectpooler pooler;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = pooler.SpawnFromPools("Bullet", firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}