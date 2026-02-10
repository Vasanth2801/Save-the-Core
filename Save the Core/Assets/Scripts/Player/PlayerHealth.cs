using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int minHealth;

    private void Start()
    {
        minHealth = maxHealth;
    }

    public void PlayerDamage(int  damage)
    {
        minHealth -= damage;

        if(minHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
