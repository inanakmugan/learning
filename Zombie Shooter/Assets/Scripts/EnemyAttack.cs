using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target;

    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        Debug.Log("BANG BANG!");
        target.DecreaseHealth(damage);


    }
}
