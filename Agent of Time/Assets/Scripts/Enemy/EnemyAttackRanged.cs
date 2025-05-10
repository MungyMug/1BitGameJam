using UnityEngine;

public class EnemyAttackRanged : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemyRb2d;
    [SerializeField] Rigidbody2D playerRb2d;

    [SerializeField] EnemyStats enemyStats;

    [Header("Target")]
    [SerializeField] PlayerStats playerStats;

    [Header("Animation")]
    [SerializeField] private Animator animator;


    private float lastAttackTime;
    private bool isWaitingAfterShoot;

    //Reference to movement script
    [SerializeField] EnemyMovement enemyMovement;

    void Update()
    {
        if(playerRb2d != null)
        {
            RangeEnemyBehavior();
        }
    }

    void RangeEnemyBehavior()
    {
        float distanceToPlayer = Vector2.Distance(enemyRb2d.position, playerRb2d.position);

        if (isWaitingAfterShoot && Time.time < lastAttackTime + enemyStats.PauseAfterAttack)
            return;

        if (isWaitingAfterShoot && Time.time >= lastAttackTime + enemyStats.PauseAfterAttack)
            isWaitingAfterShoot = false;

        if (distanceToPlayer <= enemyStats.AttackRange && enemyStats.AttackPower != 0)
        {
            if (Time.time >= lastAttackTime + enemyStats.AttackCooldown)
            {
                Debug.Log("Enemy fires a bullet!");

                animator.SetTrigger("Attack");
                playerStats.TakeDamage(enemyStats.AttackPower);
                Debug.Log(playerStats.HP);

                lastAttackTime = Time.time;
                isWaitingAfterShoot = true;
            }
        }
        else
        {
            //Let movement script handle movement
            enemyMovement.MoveTowardsPlayer();
        }
    }
}
