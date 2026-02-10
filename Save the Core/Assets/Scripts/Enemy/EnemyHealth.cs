using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private int minHealth;

    void Start()
    {
        minHealth = maxHealth;
    }

    public void EnemyDamage(int damage)
    {
        minHealth -= damage;

        if (minHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}