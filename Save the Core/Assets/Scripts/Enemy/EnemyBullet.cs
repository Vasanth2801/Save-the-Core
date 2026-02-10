using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    PlayerHealth health;
    Energy energy;

    private void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
        energy = FindObjectOfType<Energy>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            health.PlayerDamage(10);
        }

        if(collision.gameObject.CompareTag("Energy"))
        {
            energy.EnergyDamage(10);
        }

        gameObject.SetActive(false);
    }
}