using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private AttackType attackType;
    public AttackType AttackType => attackType;

    [Header("HealthPoint")]
    [SerializeField] private int hp;
    public int HP => hp;

    [Header("Movement")]
    [SerializeField] private int movementSpeed;
    public int MovementSpeed => movementSpeed;

    [Header("Attacking")]
    [SerializeField] private int attackPower;
    public int AttackPower => attackPower;

    [SerializeField] private float attackRange;
    public float AttackRange => attackRange;

    // How many times enemy can cycle their attack
    [SerializeField] private float attackCooldown;
    public float AttackCooldown => attackCooldown;

    // How long the enemy will stop after they shoot a bullet
    [SerializeField] private float pauseAfterAttack;
    public float PauseAfterAttack => pauseAfterAttack;

}

