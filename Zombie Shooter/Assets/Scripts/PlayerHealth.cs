using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100;

    public void DecreaseHealth(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
