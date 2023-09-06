using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100;

    public void TakeDamage(float Damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints = hitPoints - Damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
