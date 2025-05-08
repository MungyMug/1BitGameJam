using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private AttackType attackType;
    public AttackType AttackType => attackType;

    [Header("HealthPoint")]
    [SerializeField] private int hp;
    public int HP
    {
        get => hp;
        set => hp = Mathf.Max(0, value);
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

