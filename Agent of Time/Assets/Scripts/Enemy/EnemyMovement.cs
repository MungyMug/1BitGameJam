using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] EnemyStats enemyStats;
    [SerializeField] Rigidbody2D enemyRb2d;

    [Header("Target")]
    [SerializeField] Rigidbody2D playerRb2d;

    public void MoveTowardsPlayer()
    {
        Vector2 newPos = Vector2.MoveTowards(enemyRb2d.position, playerRb2d.position, enemyStats.MovementSpeed * Time.deltaTime);
        enemyRb2d.MovePosition(newPos);
    }
}
