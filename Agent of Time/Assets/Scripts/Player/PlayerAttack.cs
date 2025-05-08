using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("Sweeping Attack")]
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
                // Damage logic here
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 mouseWorldPos = Application.isPlaying ? Camera.main.ScreenToWorldPoint(Input.mousePosition) : transform.right;
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Vector2 leftLimit = Quaternion.Euler(0, 0, -attackAngle / 2f) * direction;
        Vector2 rightLimit = Quaternion.Euler(0, 0, attackAngle / 2f) * direction;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftLimit * attackRadius);
        Gizmos.DrawRay(transform.position, rightLimit * attackRadius);
    }

}
