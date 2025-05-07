using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] Rigidbody2D enemyRb2d;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Rigidbody2D playerRb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb2d.transform.position = Vector2.MoveTowards(enemyRb2d.transform.position, playerRb2d.transform.position, moveSpeed * Time.deltaTime);
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
