using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] EnemyStats enemyStats;
    [SerializeField] Rigidbody2D enemyRb2d;

    [Header("Target")]
    private Rigidbody2D playerRb2d;
    private PlayerStats playerStats;

    void Start()
    {
        if (playerRb2d == null)
            playerRb2d = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

        if (playerStats == null)
            playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }


    public void MoveTowardsPlayer()
    {
        Vector2 newPos = Vector2.MoveTowards(enemyRb2d.position, playerRb2d.position, enemyStats.MovementSpeed * Time.deltaTime);
        enemyRb2d.MovePosition(newPos);
    }
}
