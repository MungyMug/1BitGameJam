using UnityEngine;
using UnityEngine.Analytics;

public class PlayerLoop : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerAttack playerAttacks;
    [SerializeField] PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if (playerMovement != null)
        {
            playerMovement.PlayerNormalMovement();
        }
        else
        {
            Debug.Log("Player Movement not attached.");
        }

        if (playerAttacks != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAttacks.PerformSweepAttack();
            }
        }
        else
        {
            Debug.Log("Player Movement not attached.");
        }


    }
}
