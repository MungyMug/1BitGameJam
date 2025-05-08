using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private AttackType attackType;
    public AttackType AttackType => attackType;

    [Header("HealthPoint")]
    [SerializeField] private int hp;
    public int HP => hp;
    public void TakeDamage(int amount)
    {
        hp = Mathf.Max(0, hp - amount);

        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    [Header("Movement")]
    [SerializeField] private int movementSpeed;
    public int MovementSpeed => movementSpeed;

    [Header("Attacking")]
    [SerializeField] private int attackPower;
    public int AttackPower => attackPower;

    [SerializeField] private float attackRange;
    public float AttackRange => attackRange;
}

