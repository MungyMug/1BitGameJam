using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemyRb2d;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
