using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Rigidbody2D playerRb2d;

    public void PlayerNormalMovement()
    {
        playerRb2d.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * playerStats.MovementSpeed;
    }
}
