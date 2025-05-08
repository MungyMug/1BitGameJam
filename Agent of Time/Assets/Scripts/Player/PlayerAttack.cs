using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Sweeping Attack")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] float attackRadius = 2f;
    [SerializeField] float attackAngle = 60f;
    [SerializeField] LayerMask enemyLayer;

    public void PerformSweepAttack()
    {
        // Step 1: Get mouse world position
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionToMouse = (mouseWorldPos - transform.position).normalized;

        // Step 2: Overlap enemies within range
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            Vector2 dirToTarget = ((Vector2)hit.transform.position - (Vector2)transform.position).normalized;
            float angle = Vector2.Angle(directionToMouse, dirToTarget);

            if (angle <= attackAngle / 2f)
            {
                Debug.Log("Enemy hit: " + hit.name);

                EnemyStats enemyStats = hit.GetComponentInParent<EnemyStats>();

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(playerStats.AttackPower);
                }
            }
        }
    }
}
