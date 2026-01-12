using UnityEngine;

public class EnemyAttackPlayer : MonoBehaviour
{
    private PlayerHealth playerHealth; // Changed from public to private
    public static bool gameEndStatus = false;

    void Start()
    {
        // Automatically find the Playerhp component
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            PayCost(1);
        }
        
    }
    void PayCost(int cost)
    {
        Debug.Log("take dmggg");
        playerHealth.currentHealth -= cost;
        playerHealth.SetHealth(playerHealth.currentHealth); // Make sure this matches your PlayerMana script

        if (playerHealth.currentHealth <= 0) {
            Debug.Log("end");
            gameEndStatus = true;
        }

    }
}
