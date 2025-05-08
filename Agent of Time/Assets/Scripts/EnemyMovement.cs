using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] Rigidbody2D enemyRb2d;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Rigidbody2D playerRb2d;

    [Header("Range Enemy Settings")]
    [SerializeField] float attackRange = 3f;
    [SerializeField] float attackCooldown = 1.5f;
    [SerializeField] float pauseAfterShoot = 1.0f;

    private bool isWaitingAfterShoot;
    private float lastAttackTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameObject.tag)
        {
            case "MeleeEnemy":
                MeleeEnemyMovement();
                break;
            case "RangeEnemy":
                RangeEnemyMovement();
                break;
            default:
                Debug.LogWarning("No enemy type found");
                break;
        }
    }

    void MeleeEnemyMovement()
    {
        enemyRb2d.transform.position = Vector2.MoveTowards(enemyRb2d.transform.position, playerRb2d.transform.position, moveSpeed * Time.deltaTime);
    }

    void RangeEnemyMovement()
    {
        if (isWaitingAfterShoot && Time.time < lastAttackTime + pauseAfterShoot)
        {
            return; // Do nothing
        }

        if (isWaitingAfterShoot && Time.time >= lastAttackTime + pauseAfterShoot)
        {
            isWaitingAfterShoot = false;
        }

        float distanceToPlayer = Vector2.Distance(enemyRb2d.position, playerRb2d.position);

        if (distanceToPlayer <= attackRange)
        {
            // Within attack range
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Debug.Log("Enemy fires a bullet!");
                lastAttackTime = Time.time;
                isWaitingAfterShoot = true; // Enter wait state
            }
        }
        else
        {
            // Move towards player
            Vector2 newPos = Vector2.MoveTowards(enemyRb2d.position, playerRb2d.position, moveSpeed * Time.deltaTime);
            enemyRb2d.MovePosition(newPos);
        }

        //// Optional: horizontal movement clamp
        //float clampedX = Mathf.Clamp(enemyRb2d.position.x, -5f, 5f);
        //enemyRb2d.position = new Vector2(clampedX, enemyRb2d.position.y);
    }
}
