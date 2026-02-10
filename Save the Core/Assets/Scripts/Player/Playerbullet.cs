using UnityEngine;

public class Playerbullet : MonoBehaviour
{
    EnemyHealth health;

    private void Start()
    {
        health = FindObjectOfType<EnemyHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health.EnemyDamage(10);
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}