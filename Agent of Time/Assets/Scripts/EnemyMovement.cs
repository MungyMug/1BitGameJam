using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] Rigidbody2D enemyRb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with player
            Debug.Log("Enemy collided with player!");
        }
    }
}
