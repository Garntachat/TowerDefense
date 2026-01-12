using UnityEngine;

public class evolution2 : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int ManaRequired = 1;
    private PlayerMana playerMana; // Changed from public to private



    void Start()
    {
        // Automatically find the PlayerMana component
        playerMana = FindObjectOfType<PlayerMana>();
        if (playerMana == null)
        {
            Debug.LogError("PlayerMana component not found in scene!");
        }
        
    }
    private void OnMouseDown()
    {
        if (playerMana.currentMana >= ManaRequired) // Check mana first
            {
                Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                Destroy(gameObject);
                PayCost(ManaRequired);
            }
    }
    void PayCost(int cost)
    {
        playerMana.currentMana -= cost;
        playerMana.SetHealth(playerMana.currentMana); // Make sure this matches your PlayerMana script
    }
}